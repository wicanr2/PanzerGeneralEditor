#!/usr/bin/env python3
r"""
PG DATA explorer
=================

Panzer General 1994 (SSI, DOS/Win95) 安裝目錄的探勘工具。
PG 的 unit graphic 不在 PG-cht.exe (PE resource 只有 app icon),
而是埋在 game install 目錄下的 DATA/ 內的 SSI 自家格式檔案。

這支腳本不直接 extract icon (因為 SHP 變體很多,沒有 ground truth
不敢硬解);它先把資料攤開,讓我跟 user 一起決定下一步:

    1. 列出 DATA/ 內每個檔案的大小、magic、entropy
    2. 用 strings 抽出 ASCII 文字 (找線索:檔頭格式名、palette、unit name)
    3. 對疑似 sprite collection 的檔 (.SHP / .ICN / .DAT)
       dump 前 256 byte 的 hex,給 PE/ICN/SHP 格式比對

用法:

    docker run --rm -v "$PWD":/work -v "/path/to/Panzer General":/pg \\
        python:3.11-slim python3 /work/tools/pg-data-explorer.py /pg

或本機 (前提:有 python3):

    python3 tools/pg-data-explorer.py /path/to/Panzer\ General

輸出:tools/explore-report.md
"""
from __future__ import annotations

import sys
import os
import math
import binascii
from pathlib import Path

SUSPECT_EXTS = {".SHP", ".ICN", ".DAT", ".PAL", ".LBM", ".PCX", ".CEL", ".PIC", ".SPR"}
TEXTUAL_EXTS = {".STR", ".TXT", ".SCN", ".CAM"}


def entropy(data: bytes) -> float:
    """Shannon entropy in bits/byte; high ≈ compressed, low ≈ text/palette."""
    if not data:
        return 0.0
    counts = [0] * 256
    for b in data:
        counts[b] += 1
    n = len(data)
    e = 0.0
    for c in counts:
        if c:
            p = c / n
            e -= p * math.log2(p)
    return e


def detect_magic(head: bytes) -> str:
    if head.startswith(b"FORM") and b"ILBM" in head[:16]:
        return "IFF/ILBM (PC Paintbrush family)"
    if head.startswith(b"FORM") and b"PBM " in head[:16]:
        return "IFF/PBM (DeluxePaint)"
    if head[:2] == b"BM":
        return "Windows BMP"
    if head[:4] == b"\x0AC\x0AY\x0AB":
        return "ZSoft PCX"
    if head[:3] == b"GIF":
        return "GIF"
    if head[:8] == b"\x89PNG\r\n\x1a\n":
        return "PNG"
    if head[:2] == b"PK":
        return "ZIP"
    if head[:2] == b"\x1f\x9d":
        return "compress (.Z)"
    if head[:3] == b"SHP":
        return "ASCII 'SHP' header"
    if head[:4] == b"PSGN":
        return "SSI Panzer General signature?"
    return "unknown"


def ascii_runs(data: bytes, min_len: int = 5) -> list[str]:
    out = []
    cur = []
    for b in data:
        if 0x20 <= b < 0x7F:
            cur.append(chr(b))
        else:
            if len(cur) >= min_len:
                out.append("".join(cur))
            cur = []
    if len(cur) >= min_len:
        out.append("".join(cur))
    return out


def explore_file(path: Path, head_bytes: int = 256, max_strings: int = 30) -> dict:
    data = path.read_bytes()
    head = data[:head_bytes]
    return {
        "name": path.name,
        "size": len(data),
        "ext": path.suffix.upper(),
        "magic": detect_magic(head),
        "entropy_head": round(entropy(head), 3),
        "entropy_all": round(entropy(data), 3),
        "head_hex": binascii.hexlify(head[:64]).decode(),
        "strings": ascii_runs(data)[:max_strings],
    }


def fmt_md(info: dict) -> str:
    lines = [
        f"### `{info['name']}`",
        "",
        f"- size: **{info['size']:,} bytes**",
        f"- magic: `{info['magic']}`",
        f"- entropy head/all: {info['entropy_head']} / {info['entropy_all']}",
        f"- head bytes (hex):",
        "  ```",
        f"  {info['head_hex']}",
        "  ```",
    ]
    if info["strings"]:
        lines.append("- ASCII strings (first ≤30):")
        lines.append("  ```")
        for s in info["strings"]:
            lines.append(f"  {s}")
        lines.append("  ```")
    return "\n".join(lines)


def main(argv: list[str]) -> int:
    if len(argv) < 2:
        print(__doc__)
        return 2

    root = Path(argv[1]).expanduser().resolve()
    if not root.exists():
        print(f"not found: {root}", file=sys.stderr)
        return 1

    # prefer DATA/ subfolder, fall back to root
    data_dir = root / "DATA"
    if not data_dir.is_dir():
        data_dir = root
    print(f"scanning: {data_dir}")

    files = sorted(p for p in data_dir.iterdir() if p.is_file())
    print(f"found {len(files)} files")

    report = [
        f"# PG DATA explore report",
        "",
        f"source: `{data_dir}`",
        f"files: {len(files)}",
        "",
        "## Summary",
        "",
        "| File | Size | Ext | Magic | Entropy |",
        "|------|-----:|-----|-------|--------:|",
    ]

    # Summary table
    detailed: list[dict] = []
    for p in files:
        try:
            info = explore_file(p)
        except Exception as e:
            print(f"  ! {p.name}: {e}", file=sys.stderr)
            continue
        report.append(
            f"| `{info['name']}` | {info['size']:,} | {info['ext']} | "
            f"{info['magic']} | {info['entropy_all']} |"
        )
        if info["ext"] in SUSPECT_EXTS or info["entropy_all"] > 7.2 \
                or info["size"] > 50_000:
            detailed.append(info)

    report.append("")
    report.append("## Suspect files (likely sprite / palette / compressed)")
    report.append("")
    for info in detailed:
        report.append(fmt_md(info))
        report.append("")

    out_path = Path(__file__).resolve().parent / "explore-report.md"
    out_path.write_text("\n".join(report), encoding="utf-8")
    print(f"report → {out_path}")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
