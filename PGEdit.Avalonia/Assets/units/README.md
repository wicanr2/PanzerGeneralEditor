# Unit Icons — per-unit (from PG TILEART.DAT)

256 個 PNG (`u000.png` ~ `u255.png`),從 PG 1994 `ART/TILEART.DAT` 中的
`u####` series 抽出的 hex unit silhouette,每張 60×50 pixel,hex 形狀。

## Mapping 機制

PG 真實邏輯,**per unit** (而非 per type):

```
EQP 50-byte record offset 42 = _little_icon byte (0..255)
                ↓
        Assets/units/u<NN>.png
```

例如:
- BF109e (Fighter) `_little_icon = 0x01` → `u001.png` 戰機側面 silhouette
- PzIA (Tank) `_little_icon = 0x13 (19)` → `u019.png` Panzer I 戰車輪廓
- Tiger II `_little_icon = ?` → 對應 Tiger II 自己的 sprite

這跟 PG 遊戲畫面上每個 hex 內顯示的 unit icon 完全一致。

## 為何不再用 per-type 18 個?

之前嘗試從 `ART.DAT` 抽 36×24 silhouette per type — 那只是 purchase 視窗
的 UI button,**不是** hex 內的真實 unit icon。所有 unit 共用 18 張會丟失
PG 原本「每個 unit 一張 icon」的視覺資訊 (例如 Tiger I vs Tiger II 看起
來會一樣)。

## Palette

目前用 greyscale fallback (shape 清楚但 team colour 沒對)。要真正的彩色
需要解 SSI CPal 6698-byte 結構,後續 TODO。

## 來源

```
PG-cht-1.2_繁中化_20260519-wine/ART/TILEART.DAT  (888 KB)
  ↓ tools/extract-art-dat.py
  ↓ TOC: 919 entries → 912 RLEi sprites
  ↓ filter prefix='u', size=60x50 → 256 个 hex unit
PGEdit.Avalonia/Assets/units/u000.png ~ u255.png
```
