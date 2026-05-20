# PG DATA 探勘工具

> Panzer General (SSI 1994) unit icon **不在** `PG-cht.exe` 內 — PE resource 只
> 含 app icon + cursor。要拿到 18 個 unit type 的 sprite,得從原版 PG 安裝目錄
> 的 `DATA/` 挖。

由於 PG 用的是 SSI 自家的 `.SHP / .ICN / .CEL` 變體,沒有公開規格,沒有
ground-truth 直接硬解風險高 (會抽出亂碼)。所以這裡分兩步走:

## Step 1 — explorer 先攤開 DATA/

依 L.CY hard rule (不污染系統),用 docker:

```bash
docker run --rm \
    -v "$PWD":/repo \
    -v "/path/to/Panzer General":/pg:ro \
    -u "$(id -u):$(id -g)" \
    python:3.11-slim \
    python3 /repo/tools/pg-data-explorer.py /pg
```

(本機已有 python3 也可直接跑)
```bash
python3 tools/pg-data-explorer.py /path/to/Panzer\ General/
```

腳本不需要任何外部相依,只用 stdlib。會掃 DATA/ 下每個檔,
寫出 `tools/explore-report.md`:

- 每個檔的大小、副檔名、magic、entropy
- ASCII 字串 (找格式名 / palette label / unit 名線索)
- 疑似 sprite 檔的前 64 byte hex

**請把這份 explore-report.md 給我,**我就能判斷 SHP / ICN 的具體 layout,
再寫真正的 extractor。

## Step 2 — extractor (尚未實作,等 Step 1 結果)

之後會新增 `tools/extract-unit-icons.py`,輸出 18 張 PNG 到
`PGEdit.Avalonia/Assets/units/00.png ~ 11.png`。
編輯器啟動時 `UnitIconProvider` 會自動載入,沒有檔案就 fallback 到漢字。

## 候選格式參考 (給之後比對用)

- IFF/ILBM (FORM…ILBM):Amiga / DeluxePaint 用,SSI 早期遊戲有用
- IFF/PBM:同 family 的 chunky 變體
- PCX:DOS 時代普遍格式
- 自家 SHP:通常為「N 個 frame 的 header table + RLE-paletted bitmap」
- 自家 ICN:8x8 tile 索引

PG 1994 比較可能用 自家 SHP + 單獨 .PAL,需從 .PAL 拿 256 色 palette 才能上色。
