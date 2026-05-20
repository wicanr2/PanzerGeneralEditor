#!/usr/bin/env python3
"""
Generate tools/icon-picker.html — a single-file gallery to pick the
sprite for each of the 18 unit types in PGEdit.Avalonia.

The HTML embeds:
  - 18 unit-type slots (current mapping read from Assets/units/<idx>.png file existence + filename)
  - All sprites listed in tools/art-out/INDEX.tsv (id, w_x_h, size)
  - JS to click-assign sprite to type, filter by size, search by id,
    save state in localStorage, and emit a copy-paste shell script.

Open the resulting HTML directly in a browser (file://); image paths
are relative (art-out/<id>.png) so the same folder layout must be kept.
"""
from __future__ import annotations

import json
import re
import shutil
from pathlib import Path

ROOT = Path(__file__).resolve().parent
REPO = ROOT.parent
INDEX = ROOT / "art-out" / "INDEX.tsv"
ASSETS = REPO / "PGEdit.Avalonia" / "Assets" / "units"

UNIT_TYPES = [
    ("00", "Infantry",     "步兵團"),
    ("01", "Tank",         "戰車"),
    ("02", "Recon",        "偵查車"),
    ("03", "AntiTank",     "反戰車砲"),
    ("04", "Artillery",    "砲兵"),
    ("05", "AntiAircraft", "防空砲"),
    ("06", "AirDefense",   "防空高射砲"),
    ("07", "Fort",         "碉堡"),
    ("08", "Fighter",      "戰鬥機"),
    ("09", "Bomber",       "轟炸機"),
    ("0a", "LevelBomber",  "同溫層轟炸機"),
    ("0b", "Submarine",    "潛水艇"),
    ("0c", "Destroyer",    "驅逐艦"),
    ("0d", "Battleship",   "主力艦"),
    ("0e", "Carrier",      "巡洋艦"),
    ("0f", "Truck",        "裝甲車"),
    ("10", "AirTransport", "運輸機"),
    ("11", "SeaTransport", "運輸船"),
]


def load_sprites() -> list[dict]:
    rows = INDEX.read_text(encoding="utf-8").splitlines()[1:]
    out = []
    for r in rows:
        parts = r.split("\t")
        if len(parts) < 3:
            continue
        sid, wh, size = parts[0], parts[1], parts[2]
        m = re.match(r"(\d+)x(\d+)", wh)
        if not m:
            continue
        w, h = int(m.group(1)), int(m.group(2))
        out.append({"id": sid, "w": w, "h": h, "size": int(size)})
    out.sort(key=lambda s: (-(s["w"] * s["h"]), s["id"]))
    return out


def current_mapping() -> dict[str, str]:
    """Look at PGEdit.Avalonia/Assets/units/<idx>.png and reverse-resolve
    which sprite ID was copied there, by comparing bytes against art-out/."""
    if not ASSETS.exists():
        return {}
    art_out = ROOT / "art-out"
    # build a content-hash → id map for art-out (cheap; only 491 files)
    content_to_id: dict[bytes, str] = {}
    for p in art_out.glob("*.png"):
        content_to_id[p.read_bytes()] = p.stem
    mapping = {}
    for idx, _, _ in UNIT_TYPES:
        target = ASSETS / f"{idx}.png"
        if target.exists():
            sid = content_to_id.get(target.read_bytes())
            if sid:
                mapping[idx] = sid
    return mapping


HTML_TEMPLATE = r"""<!DOCTYPE html>
<html lang="zh-Hant">
<head>
<meta charset="utf-8" />
<title>PGEdit unit-icon picker</title>
<style>
  :root {
    --bg: #1B1F24; --panel: #262C33; --line: #3A434D;
    --accent: #C7A24A; --accent-dim: #7A6429;
    --text: #E8EDF2; --muted: #9AA4AE; --danger: #E2574C; --ok: #48B07B;
  }
  * { box-sizing: border-box; }
  body {
    margin: 0; padding: 0; font-family: 'Noto Sans TC', system-ui, sans-serif;
    background: var(--bg); color: var(--text); font-size: 13px;
  }
  header {
    padding: 12px 18px; background: var(--panel); border-bottom: 1px solid var(--line);
    display: flex; align-items: center; gap: 16px; position: sticky; top: 0; z-index: 10;
  }
  header h1 { font-size: 18px; margin: 0; color: var(--accent); }
  header .actions { margin-left: auto; display: flex; gap: 8px; }
  button {
    background: var(--accent); color: #0B0E12; border: 0; padding: 7px 14px;
    border-radius: 5px; font-weight: 600; cursor: pointer; font-size: 12px;
  }
  button.ghost { background: transparent; color: var(--text); border: 1px solid var(--line); }
  button:hover { filter: brightness(1.1); }

  .layout {
    display: grid; grid-template-columns: 380px 1fr; gap: 0;
    height: calc(100vh - 56px);
  }

  /* LEFT: 18 type cards */
  aside {
    background: var(--panel); border-right: 1px solid var(--line);
    overflow-y: auto; padding: 10px;
  }
  .type-card {
    display: grid; grid-template-columns: 56px 1fr auto; gap: 8px;
    align-items: center; padding: 8px; margin-bottom: 6px;
    background: #1F242A; border: 1px solid var(--line); border-radius: 6px;
    cursor: pointer; transition: border-color 0.1s;
  }
  .type-card:hover { border-color: var(--accent-dim); }
  .type-card.active { border-color: var(--accent); background: #2A2F36; }
  .type-card .preview {
    width: 56px; height: 40px; background: var(--accent);
    display: flex; align-items: center; justify-content: center; border-radius: 4px;
    overflow: hidden;
  }
  .type-card .preview img {
    width: 100%; height: 100%; object-fit: contain;
    image-rendering: pixelated;
    filter: invert(1) brightness(0.85);
  }
  .type-card .preview .glyph {
    font-size: 18px; font-weight: 600; color: #0B0E12;
  }
  .type-card .meta { min-width: 0; }
  .type-card .id { font-family: monospace; font-size: 11px; color: var(--muted); }
  .type-card .name { font-weight: 600; }
  .type-card .sid { font-family: monospace; font-size: 11px; color: var(--accent); }
  .type-card .clear { background: transparent; color: var(--danger); border: 0; padding: 4px; font-size: 16px; }

  /* RIGHT: sprite gallery */
  main { overflow-y: auto; padding: 12px; }
  .toolbar {
    display: flex; gap: 8px; margin-bottom: 12px; flex-wrap: wrap;
    position: sticky; top: 0; background: var(--bg); z-index: 5; padding: 6px 0;
  }
  .toolbar input, .toolbar select {
    background: #14181C; color: var(--text); border: 1px solid var(--line);
    padding: 6px 10px; border-radius: 5px; font-size: 12px;
  }
  .toolbar input { flex: 1; min-width: 180px; }
  .stat { color: var(--muted); font-size: 11px; align-self: center; }

  .gallery {
    display: grid; grid-template-columns: repeat(auto-fill, minmax(110px, 1fr));
    gap: 8px;
  }
  .sprite {
    background: var(--panel); border: 2px solid transparent;
    border-radius: 6px; padding: 6px; cursor: pointer;
    display: flex; flex-direction: column; align-items: center; gap: 4px;
    transition: border-color 0.1s;
  }
  .sprite:hover { border-color: var(--accent-dim); }
  .sprite.assigned { border-color: var(--ok); }
  .sprite img {
    width: 96px; height: 64px; object-fit: contain;
    image-rendering: pixelated; background: #0B0E12; border-radius: 4px;
    filter: invert(1) brightness(0.85);
  }
  .sprite .id { font-family: monospace; font-size: 11px; color: var(--accent); }
  .sprite .wh { font-family: monospace; font-size: 10px; color: var(--muted); }

  .toast {
    position: fixed; bottom: 20px; left: 50%; transform: translateX(-50%);
    background: var(--ok); color: #0B0E12; padding: 8px 16px; border-radius: 6px;
    font-weight: 600; opacity: 0; transition: opacity 0.3s; z-index: 100;
  }
  .toast.show { opacity: 1; }

  /* export modal */
  .modal {
    position: fixed; inset: 0; background: rgba(0,0,0,0.7);
    display: none; align-items: center; justify-content: center; z-index: 50;
  }
  .modal.show { display: flex; }
  .modal-card {
    background: var(--panel); border: 1px solid var(--line); border-radius: 8px;
    padding: 20px; max-width: 720px; width: 90%; max-height: 80vh; overflow: auto;
  }
  .modal pre {
    background: #0B0E12; padding: 12px; border-radius: 4px; overflow: auto;
    font-size: 11px; line-height: 1.5; color: #C8D2DC;
  }
</style>
</head>
<body>
<header>
  <h1>🎯 PGEdit unit-icon picker</h1>
  <span class="stat" id="progress">0 / 18 已指派</span>
  <div class="actions">
    <button class="ghost" onclick="resetAll()">清空</button>
    <button onclick="exportMapping()">匯出 shell 指令</button>
  </div>
</header>

<div class="layout">
  <aside id="types"></aside>
  <main>
    <div class="toolbar">
      <input id="search" placeholder="🔍  搜尋 sprite ID (4-char,可用 partial)" />
      <select id="sizeFilter">
        <option value="">所有尺寸</option>
      </select>
      <span class="stat" id="filterStat"></span>
    </div>
    <div class="gallery" id="gallery"></div>
  </main>
</div>

<div class="toast" id="toast"></div>
<div class="modal" id="modal" onclick="if(event.target===this)this.classList.remove('show')">
  <div class="modal-card">
    <h2 style="margin-top:0;color:var(--accent)">匯出 mapping</h2>
    <p>把以下 shell 指令貼到 terminal,從專案根目錄執行,即可把選好的 PNG 複製到 Assets/units/:</p>
    <pre id="exportSh"></pre>
    <p style="margin-top:14px">或 JSON (給後續工具用):</p>
    <pre id="exportJson"></pre>
    <div style="margin-top:12px;display:flex;gap:8px">
      <button onclick="copyExport('sh')">複製 shell</button>
      <button onclick="copyExport('json')" class="ghost">複製 JSON</button>
      <button onclick="document.getElementById('modal').classList.remove('show')" class="ghost">關閉</button>
    </div>
  </div>
</div>

<script>
const TYPES = __TYPES__;
const SPRITES = __SPRITES__;
const INITIAL = __INITIAL__;

let mapping = JSON.parse(localStorage.getItem('pgedit-icon-map') || 'null') || {...INITIAL};
let activeType = null;
let filterSize = '';
let filterText = '';

// --- helpers ---
function persist() {
  localStorage.setItem('pgedit-icon-map', JSON.stringify(mapping));
  updateProgress();
}
function updateProgress() {
  const n = Object.keys(mapping).length;
  document.getElementById('progress').textContent = `${n} / 18 已指派`;
}
function toast(msg) {
  const t = document.getElementById('toast');
  t.textContent = msg;
  t.classList.add('show');
  setTimeout(() => t.classList.remove('show'), 1500);
}

// --- left panel ---
function renderTypes() {
  const html = TYPES.map(([idx, en, zh]) => {
    const sid = mapping[idx];
    const isActive = activeType === idx ? ' active' : '';
    const previewBody = sid
      ? `<img src="art-out/${sid}.png" alt="${sid}">`
      : `<span class="glyph">${idx}</span>`;
    const sidLine = sid
      ? `<div class="sid">${sid}</div>`
      : `<div class="sid" style="color:var(--muted)">未指派</div>`;
    const clearBtn = sid
      ? `<button class="clear" onclick="event.stopPropagation();clearType('${idx}')" title="清除">✕</button>`
      : `<span style="width:24px"></span>`;
    return `
      <div class="type-card${isActive}" onclick="selectType('${idx}')">
        <div class="preview">${previewBody}</div>
        <div class="meta">
          <div class="id">${idx} · ${en}</div>
          <div class="name">${zh}</div>
          ${sidLine}
        </div>
        ${clearBtn}
      </div>`;
  }).join('');
  document.getElementById('types').innerHTML = html;
}

function selectType(idx) {
  activeType = activeType === idx ? null : idx;
  renderTypes();
  renderGallery();
  if (activeType) {
    toast(`選 sprite 指派給 ${idx}`);
  }
}

function clearType(idx) {
  delete mapping[idx];
  persist();
  renderTypes();
  renderGallery();
}

// --- right panel ---
function renderSizeFilter() {
  const counts = {};
  SPRITES.forEach(s => {
    const k = `${s.w}x${s.h}`;
    counts[k] = (counts[k] || 0) + 1;
  });
  const sel = document.getElementById('sizeFilter');
  Object.entries(counts).sort((a,b) => b[1]-a[1]).forEach(([sz, n]) => {
    const opt = document.createElement('option');
    opt.value = sz;
    opt.textContent = `${sz} (${n})`;
    sel.appendChild(opt);
  });
  sel.addEventListener('change', e => { filterSize = e.target.value; renderGallery(); });
}

function renderGallery() {
  const term = filterText.trim().toLowerCase();
  const filtered = SPRITES.filter(s => {
    if (filterSize && `${s.w}x${s.h}` !== filterSize) return false;
    if (term && !s.id.toLowerCase().includes(term)) return false;
    return true;
  });
  document.getElementById('filterStat').textContent =
    `顯示 ${filtered.length} / ${SPRITES.length}` +
    (activeType ? ` · 點圖指派給 ${activeType}` : '');
  const used = new Set(Object.values(mapping));
  const html = filtered.map(s => {
    const isUsed = used.has(s.id) ? ' assigned' : '';
    return `
      <div class="sprite${isUsed}" onclick="assignSprite('${s.id.replace(/'/g, "\\'")}')">
        <img src="art-out/${s.id}.png" alt="${s.id}">
        <div class="id">${s.id}</div>
        <div class="wh">${s.w}×${s.h}</div>
      </div>`;
  }).join('');
  document.getElementById('gallery').innerHTML = html;
}

function assignSprite(sid) {
  if (!activeType) {
    toast('先點左邊的 type card 選擇要指派的 unit type');
    return;
  }
  mapping[activeType] = sid;
  persist();
  toast(`✓ ${activeType} ← ${sid}`);
  renderTypes();
  renderGallery();
}

document.getElementById('search').addEventListener('input', e => {
  filterText = e.target.value;
  renderGallery();
});

function resetAll() {
  if (!confirm('清空全部 18 個 mapping?')) return;
  mapping = {};
  persist();
  renderTypes();
  renderGallery();
  toast('已清空');
}

// --- export ---
function buildExportSh() {
  const lines = ['#!/usr/bin/env bash',
                 '# 從專案根目錄 (PanzerGeneralEditor/) 執行',
                 'set -euo pipefail',
                 'cd "$(dirname "$0")/.." 2>/dev/null || true'];
  TYPES.forEach(([idx]) => {
    const sid = mapping[idx];
    if (!sid) return;
    // shell-safe: filenames may contain [, `, ', \, etc.; use python -c for portability
    const safe = sid.replace(/'/g, "'\\''");
    lines.push(`cp "tools/art-out/${safe}.png" "PGEdit.Avalonia/Assets/units/${idx}.png"`);
  });
  return lines.join('\n');
}

function buildExportJson() {
  return JSON.stringify(mapping, null, 2);
}

function exportMapping() {
  document.getElementById('exportSh').textContent = buildExportSh();
  document.getElementById('exportJson').textContent = buildExportJson();
  document.getElementById('modal').classList.add('show');
}

function copyExport(kind) {
  const el = document.getElementById(kind === 'sh' ? 'exportSh' : 'exportJson');
  navigator.clipboard.writeText(el.textContent).then(() => toast('已複製到剪貼簿'));
}

// init
renderTypes();
renderSizeFilter();
renderGallery();
updateProgress();
</script>
</body>
</html>
"""


def main() -> int:
    sprites = load_sprites()
    initial = current_mapping()

    html = HTML_TEMPLATE \
        .replace("__TYPES__", json.dumps(UNIT_TYPES, ensure_ascii=False)) \
        .replace("__SPRITES__", json.dumps(sprites, ensure_ascii=False)) \
        .replace("__INITIAL__", json.dumps(initial, ensure_ascii=False))

    out = ROOT / "icon-picker.html"
    out.write_text(html, encoding="utf-8")
    print(f"✓ {out}")
    print(f"  sprites: {len(sprites)}")
    print(f"  current mapping: {len(initial)} / 18")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
