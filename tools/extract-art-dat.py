#!/usr/bin/env python3
"""
ART.DAT extractor for Panzer General (SSI 1994).

格式 (我從 PG-cht 1.2 ART.DAT 逆向出來的):

  File header (14 bytes):
    0x00  4 bytes  zero pad
    0x04  "Indx"   magic
    0x08  4 bytes  TOC end offset (big-endian)
    0x0c  2 bytes  record count (big-endian uint16)
    0x0e  "Indx"   marker
    0x12  "Indx"
    0x16  4 bytes  ?
    0x1a  4 bytes  ?
    0x1e  "xxxx"   padding
    0x22  "Vers"   version chunk TOC entry (12 bytes)
    0x2e  ...      record entries start

  TOC entry (16 bytes each):
    4 bytes  ID    (e.g. "aaNl")
    4 bytes  TYPE  ("CPal" or "RLEi")
    4 bytes  offset (big-endian)
    4 bytes  size   (big-endian)

  RLEi chunk header (16 bytes):
    "RLEi" + 4-byte payload size + 8 bytes ID×2 (echoed)
    + 4 bytes flags + 2+2 width/height + 2+2 originX/originY

  RLE codes:
    0xFF NN          = NN transparent pixels
    0x00 XX          = end of row, XX = next row's left padding
    0x01..0x7F NN    = run of (code) pixels of color NN
    0x80..0xFE NN    = literal: (code & 0x7F) pixels follow

  Note: palette decoding is not implemented (SSI custom CPal layout
  6698 bytes ≠ standard 768-byte 256×RGB).  As a workaround we
  output PNGs using a synthetic VGA-like palette.  Shapes are
  recoverable; team colours may look wrong until we work out CPal.

Usage:
    python3 tools/extract-art-dat.py /path/to/PG/ART/ART.DAT [outdir]
"""

from __future__ import annotations

import sys
import struct
from pathlib import Path
from dataclasses import dataclass

try:
    from PIL import Image
except ImportError:
    print("PIL/Pillow required.  install: pip install Pillow", file=sys.stderr)
    sys.exit(2)


@dataclass
class Entry:
    id: str
    type: str
    offset: int
    size: int


def parse_toc(buf: bytes) -> list[Entry]:
    """Walk TOC by pattern-matching plausible 16-byte entries."""
    entries: list[Entry] = []
    # Skip header; start scanning from 0x22 where Vers entry sits.
    pos = 0x22
    while pos + 16 <= len(buf):
        tag = buf[pos:pos+4]
        if tag == b"Vers":
            # special 12-byte entry: type + offset + size
            off, sz = struct.unpack(">II", buf[pos+4:pos+12])
            entries.append(Entry("Vers", "Vers", off, sz))
            pos += 12
            continue
        # 4-char ID, 4-char type, 4-byte off, 4-byte size
        if not all(0x20 <= b < 0x80 for b in tag):
            break  # ID must be printable ASCII
        t = buf[pos+4:pos+8]
        if t not in (b"CPal", b"RLEi"):
            break
        off, sz = struct.unpack(">II", buf[pos+8:pos+16])
        if off + sz > len(buf):
            break
        entries.append(Entry(tag.decode("ascii"), t.decode("ascii"), off, sz))
        pos += 16
    return entries


def decode_rle(payload: bytes, w: int, h: int) -> bytes:
    """Decode RLE codes → flat indexed bitmap, w*h bytes.

    Codes:
      0xFF NN          : NN transparent pixels (use 0)
      0x00 XX          : end of row marker
      0x01..0x7F NN    : run of count pixels, all colour NN
      0x80..0xFE NN+ : literal, (code & 0x7F) pixels follow
    """
    pixels = bytearray(w * h)
    p = 0  # input pointer
    row = 0
    col = 0
    while p < len(payload) and row < h:
        c = payload[p]; p += 1
        if c == 0xFF:
            if p >= len(payload): break
            n = payload[p]; p += 1
            col += n
        elif c == 0x00:
            # end of row; next byte = origin x of next row (or pad)
            if p < len(payload):
                _ = payload[p]; p += 1
            row += 1
            col = 0
        elif c & 0x80:
            n = c & 0x7F
            if p + n > len(payload): break
            for i in range(n):
                if col < w and row < h:
                    pixels[row * w + col] = payload[p + i]
                col += 1
            p += n
        else:
            n = c
            if p >= len(payload): break
            colour = payload[p]; p += 1
            for _ in range(n):
                if col < w and row < h:
                    pixels[row * w + col] = colour
                col += 1
    return bytes(pixels)


def fallback_palette(mode: str = "white") -> list[int]:
    """Palette without true CPal:
       mode='white' → 0=transparent (rendered black, alpha 0), 1..255=純白 silhouette
       mode='grey'  → 0=transparent, 1..255=greyscale ramp
    """
    pal = []
    if mode == "white":
        for i in range(256):
            if i == 0:
                pal.extend([0, 0, 0])
            else:
                pal.extend([255, 255, 255])
    else:
        for i in range(256):
            if i == 0:
                pal.extend([0, 0, 0])
            else:
                v = 40 + ((i * 215) // 255)
                pal.extend([v, v, v])
    return pal


def main(argv: list[str]) -> int:
    if len(argv) < 2:
        print(__doc__)
        return 2

    src = Path(argv[1])
    outdir = Path(argv[2]) if len(argv) > 2 else \
             Path(__file__).resolve().parent / "art-out"
    outdir.mkdir(parents=True, exist_ok=True)

    buf = src.read_bytes()
    print(f"loaded {len(buf):,} bytes from {src}")

    toc = parse_toc(buf)
    print(f"TOC entries: {len(toc)}")
    sprites = [e for e in toc if e.type == "RLEi"]
    palettes = [e for e in toc if e.type == "CPal"]
    print(f"  RLEi sprites: {len(sprites)}")
    print(f"  CPal palettes: {len(palettes)}")

    pal = fallback_palette()

    summary: list[str] = []
    ok = 0
    fail = 0
    for s in sprites:
        chunk = buf[s.offset:s.offset + s.size]
        if len(chunk) < 24 or chunk[:4] != b"RLEi":
            fail += 1
            continue
        # parse RLEi header
        try:
            w = struct.unpack(">H", chunk[0x14:0x16])[0]
            h = struct.unpack(">H", chunk[0x16:0x18])[0]
        except struct.error:
            fail += 1
            continue
        if not (1 <= w <= 512 and 1 <= h <= 512):
            fail += 1
            continue
        payload = chunk[0x1c:]
        try:
            pixels = decode_rle(payload, w, h)
        except Exception:
            fail += 1
            continue

        img = Image.frombytes("P", (w, h), pixels)
        img.putpalette(pal)
        out = outdir / f"{s.id}.png"
        # index 0 = transparent (tRNS chunk),其餘非零 = 純白 silhouette
        img.save(out, transparency=0)
        summary.append(f"{s.id}\t{w}x{h}\t{s.size}\t→ {out.name}")
        ok += 1

    print(f"extracted: {ok} ok, {fail} skipped")
    idx = outdir / "INDEX.tsv"
    idx.write_text("id\tw_x_h\tsize\tpng\n" + "\n".join(summary), encoding="utf-8")
    print(f"index → {idx}")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
