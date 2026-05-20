# PG 資料探勘與抽取工具

從 Panzer General 1994 (SSI) 安裝目錄解出單位圖示與其他遊戲 sprite 的腳本集。
本目錄的工具不會修改原版遊戲資料,僅讀取 + 輸出 PNG。

## 使用情境

- 想換掉編輯器內的單位圖示 (例如改用其他國家/版本的 PG 安裝)
- 想對 `ART/*.DAT` 內的 sprite 做研究、預覽或二次創作
- 想了解 PG 自家 chunk-based 資料格式

## 工具列表

### `pg-data-explorer.py`

掃描指定的 PG 資料目錄,輸出每個檔案的基本資訊 (大小、magic、entropy、
ASCII 字串、hex header) 到 `tools/explore-report.md`,用來辨識自家格式。

```bash
# Docker (不污染本機 Python 環境)
docker run --rm \
    -v "$PWD":/repo \
    -v "/path/to/Panzer General":/pg:ro \
    -u "$(id -u):$(id -g)" \
    python:3.11-slim \
    python3 /repo/tools/pg-data-explorer.py /pg

# 本機 (有 python3 即可,只用 stdlib)
python3 tools/pg-data-explorer.py /path/to/Panzer\ General/
```

### `extract-art-dat.py`

解析 SSI chunk-based `.DAT` 容器 (`Indx` TOC + `RLEi` RLE-encoded indexed
bitmap + `CPal` palette),每個 sprite 輸出一張 PNG。

```bash
# 跑在 ART.DAT 上會抽 491 張 sprite (UI button, portrait, frame…)
python3 tools/extract-art-dat.py \
    /path/to/Panzer\ General/ART/ART.DAT \
    tools/art-out/

# 跑在 TILEART.DAT 上會抽 912 張 sprite,其中 256 個 u### 是 hex 內單位圖示
python3 tools/extract-art-dat.py \
    /path/to/Panzer\ General/ART/TILEART.DAT \
    tools/tileart-out/
```

需要 Python 3.10+ 與 Pillow:

```bash
pip install Pillow
# 或 docker:
docker run --rm -v "$PWD":/repo -w /repo \
    python:3.11-slim sh -c "pip install Pillow && python3 tools/extract-art-dat.py ART.DAT out/"
```

### `build-icon-picker.py` + `icon-picker.html`

產出 self-contained 的 HTML sprite gallery,可在瀏覽器內互動:

- 顯示 18 個 unit type slot (左) 跟 491 個 sprite (右)
- 點 slot → 進入指派模式,點 sprite → 指派
- 依尺寸過濾、按 ID 搜尋,結果存在 localStorage
- 匯出 shell 指令把選好的 PNG 複製到 `PGEdit.Avalonia/Assets/units/`

```bash
python3 tools/build-icon-picker.py
xdg-open tools/icon-picker.html
```

## SSI chunk-based 格式速查

`ART.DAT` / `TILEART.DAT` 共用以下結構:

| 標籤 | 意思 | 內容 |
|---|---|---|
| `Indx` | Index / TOC | 開頭 marker + table of contents |
| `Vers` | Version | 版本資訊 |
| `CPal` | Color Palette | 256-color palette (SSI 自家擴充 6698 bytes) |
| `RLEi` | RLE Indexed | RLE 壓縮的 8-bit indexed bitmap |

TOC entry (16 bytes):

```
4 bytes  ID    (e.g. "u001", "aaNl")
4 bytes  TYPE  ("CPal" or "RLEi")
4 bytes  offset (big-endian)
4 bytes  size   (big-endian)
```

RLEi chunk header (16 bytes) 後接 RLE codes:

```
0xFF NN          NN 個透明 pixel
0x00 XX          結束本 row
0x01..0x7F NN    run: (count, colour) ─ 同色 N 個 pixel
0x80..0xFE       literal: (code & 0x7F) 個 pixel,後面接 N 個色 byte
```

## TILEART.DAT 內單位圖示 (核心發現)

- `u000` ~ `u255`:256 個 60×50 hex 形狀單位 silhouette
- `m000` ~:240 個 60×50 地形 hex
- `s000` ~:48 個結構物 / 補給點
- `f000` ~:24 個 20×13 國旗

EQP record 第 42 byte (`_little_icon`) 直接 index 到 `u<NN>.png`。
例如 `BF109e._little_icon = 0x01` → `u001.png` 是戰機 silhouette。

詳細 mapping 見 [`PGEdit.Avalonia/Assets/units/README.md`](../PGEdit.Avalonia/Assets/units/README.md)。

## 注意事項

- `tools/art-out/` 與 `tools/tileart-out/` 內的抽出檔案不會 commit 進 repo
  (見 `.gitignore`),重抽即可。
- Palette 目前用 fallback (純白 silhouette + 透明背景),真實 SSI CPal
  6698-byte 結構尚未完全解析。
- 請尊重 SSI / Strategic Simulations Inc. 對原版 Panzer General 資源的智財,
  本工具僅供研究與個人 modding 使用。
