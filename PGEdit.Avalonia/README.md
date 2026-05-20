# PGEdit.Avalonia

裝甲元帥修改器 — Modern UX 重寫版,基於 .NET 8 + Avalonia 11。

> 既有 WinForms 版 (`PGEdit/`) 保留不動,本目錄為平行新版。
> 兩者共用底層 `PGEQReader` 的 .cs source,以 `<Compile Include="..\PGEQReader\*.cs" Link="..." />` 連結;不需修改原 .NET 4.5 csproj。

## UX 改進對照

| 舊版 (WinForms) | 新版 (Avalonia) |
|---|---|
| 18 欄位平鋪、無分組 | 卡片分組 (識別 / 攻擊 / 防禦 / 機動 / 經濟 / 進階) |
| 9pt 新細明體,固定 pixel 佈局 | Inter + Noto Sans TC,DPI-aware,可拉伸 |
| 無 Dark mode | 預設 Dark,可切 Light |
| ListBox 純文字 | 單位類別 glyph + 搜尋 (`SearchQuery` 即時過濾) |
| `MouseHover` 才顯示說明 | `Watermark` + `ToolTip` + 永遠可見的 hint |
| 直接覆寫 .EQP | 第一次儲存自動 `*.YYYYMMDD-HHMMSS.bak` |
| 無 undo / 無 diff preview | Ctrl+Z / Y、儲存前 DiffDialog 列出全部變更 |
| 純 textbox,可輸入 999 破檔 | `NumericUpDown` + `Slider` 軟上限,cost 自動 step 12 |
| `unknown1~5` 直接外露 | 收進 Expander「進階 / Raw bytes」 |

## 目錄

```
PGEdit.Avalonia/
├── PGEdit.Avalonia.csproj      ← .NET 8,SDK-style,引用 PGEQReader source
├── Program.cs                   ← 進入點,註冊 CP950
├── App.axaml / .cs              ← Fluent + 自定 dark/light palette
├── app.manifest                 ← Windows DPI awareness
├── Models/
│   ├── UnitDto.cs               ← 一筆 unit 的不可變快照
│   ├── UnitType.cs              ← enum + Registry (顯示名/glyph/分類)
│   └── StatBounds.cs            ← 軟/硬上限與 hint 文字
├── Services/
│   ├── EquipmentFileService.cs  ← 包 pgeq_reader,DTO 進出
│   ├── BackupService.cs         ← 第一次寫入前 timestamped .bak
│   └── UndoRedoService.cs       ← (Before, After) stack,深度 100
├── ViewModels/
│   ├── MainWindowViewModel.cs   ← 開檔 / 搜尋 / 儲存 / undo / redo
│   ├── UnitEditorViewModel.cs   ← 編輯區所有欄位 + IsDirty 追蹤
│   └── UnitListItemViewModel.cs ← 左側列表單筆
├── Views/
│   ├── MainWindow.axaml         ← 主視窗 mockup (左列表 / 右分組編輯)
│   └── DiffDialog.axaml         ← 儲存前差異確認
├── Controls/
│   └── StatRadarChart.cs        ← 7 軸雷達圖 (custom Control)
├── Converters/
│   └── BoolToBrushConverter.cs
└── Themes/
    └── AppTheme.axaml           ← .card / .h2 / .label 等 utility class
```

## Build (docker, 符合 L.CY hard rule)

不依賴本機 .NET SDK,從專案根目錄執行:

```bash
docker run --rm -v "$PWD":/src -w /src/PGEdit.Avalonia \
    mcr.microsoft.com/dotnet/sdk:8.0 \
    dotnet publish -c Release -r linux-x64 --self-contained \
                   -p:PublishSingleFile=true -o ./out
```

執行檔:`PGEdit.Avalonia/out/PGEdit.Avalonia`。

Windows / macOS 對應的 RID:
- Windows x64:`-r win-x64`
- macOS Apple Silicon:`-r osx-arm64`
- macOS Intel:`-r osx-x64`

## Run (開發)

```bash
docker run --rm -it -v "$PWD":/src -w /src/PGEdit.Avalonia \
    --net=host -e DISPLAY=$DISPLAY \
    -v /tmp/.X11-unix:/tmp/.X11-unix \
    mcr.microsoft.com/dotnet/sdk:8.0 \
    dotnet run
```

> Linux 桌面需 X11 forwarding;Wayland 使用者請改用 publish + 本機執行。

## 快捷鍵

| Key | Action |
|---|---|
| Ctrl+O | 開啟 .EQP |
| Ctrl+S | 儲存 (跳 DiffDialog) |
| Ctrl+Z / Ctrl+Y | Undo / Redo |
| ↑ / ↓ | 上 / 下一個單位 |

## 待辦 (尚未實作,留給後續迭代)

- 單位對比模式 (選 2~3 個單位疊圖)
- Export / Import preset (JSON)
- 完整型 Light theme 校色 (現只是反轉 dark)
- 自動偵測 PG DOS / WIN95 / Allied General 格式差異
