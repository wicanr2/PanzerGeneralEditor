# Panzer General Editor

A binary equipment-file (`PANZEQUP.EQP`) editor for **Panzer General (DOS/WIN95)** and
**Allied General**. Lets you read and modify per-unit stats: attack / defense, range,
spotting, movement, fuel, ammo, cost, etc.

Two editions ship in this repo:

| Edition | Stack | Status |
|---|---|---|
| **PGEdit.Avalonia** | .NET 8 + Avalonia 11, cross-platform (Win / Linux / macOS) | **Active** — modern UX rewrite |
| `PGEdit/` (legacy)  | WinForms + .NET 4.5, Visual Studio 2012 | Preserved as-is |

Both share the same underlying parser (`PGEQReader/`).

---

## PGEdit.Avalonia

![](images/avalonia-light-theme.png)

### Features

- **Two-column dense layout** — attack/defense left, radar+economy+mobility right;
  single screen, no scrolling needed.
- **Real PG hex unit icons** — decodes `ART/TILEART.DAT` (SSI chunk-based format
  `Indx` / `Vers` / `CPal` / `RLEi`), extracts 256 `u###` hex sprites. EQP byte 42
  (`_little_icon`) directly indexes into `Assets/units/u<NN>.png`, matching the
  exact sprite the game would render in-hex.
- **Dark / Light theme** — Notion-style white surface + blue accent (default), or
  switch via `RequestedThemeVariant`.
- **Safer editing** —
  - Auto-`.bak` (timestamped) on first save per session
  - Diff dialog before write-back lists every changed field
  - Undo / Redo (Ctrl+Z / Ctrl+Y), depth 100
  - Range-validated `NumericUpDown` instead of free-form text (cost auto-rounds to
    multiples of 12)
- **Stat radar chart** — 7-axis (soft/hard/air/naval attack + ground/air/close
  defense) per unit.
- **Search & filter** — filter unit list by name or type.
- **Large UI** — 16 px base font, 64×64 unit-icon container, generous spacing.
- **Keyboard shortcuts** — Ctrl+O open · Ctrl+S save · Ctrl+Z/Y undo/redo · ↑/↓ next/prev unit.

### Build (Docker, recommended)

No local .NET SDK required:

```bash
./PGEdit.Avalonia/docker-build.sh linux-x64
# →  PGEdit.Avalonia/out/linux-x64/PGEdit.Avalonia  (self-contained binary)
```

Other RIDs:

| Target | RID |
|---|---|
| Windows x64 | `win-x64` |
| macOS Apple Silicon | `osx-arm64` |
| macOS Intel | `osx-x64` |

### Build (local .NET 8 SDK)

```bash
cd PGEdit.Avalonia
dotnet publish -c Release -r <RID> --self-contained -p:PublishSingleFile=true -o ./out
```

### Layout

```
PGEdit.Avalonia/
├── PGEdit.Avalonia.csproj      .NET 8 SDK-style; links PGEQReader source
├── Program.cs, App.axaml/.cs   Entry + Fluent + dark/light palette
├── Models/                     UnitDto, UnitType, StatBounds, DiffRow
├── Services/                   EquipmentFileService, BackupService,
│                               UndoRedoService, UnitIconProvider
├── ViewModels/                 Main, UnitEditor, UnitListItem
├── Views/                      MainWindow.axaml, DiffDialog.axaml
├── Controls/                   StatRadarChart  (custom Avalonia Control)
├── Themes/                     AppTheme.axaml  (.card / .h2 / .label utility classes)
└── Assets/units/u000.png ~ u255.png
```

See [PGEdit.Avalonia/README.md](PGEdit.Avalonia/README.md) for more.

---

## Tools

The `tools/` directory provides utilities to inspect Panzer General data files and
re-extract unit icons from a different PG installation:

- `pg-data-explorer.py` — scans a PG `DATA/` or `ART/` folder and produces a
  report with file magic, entropy, ASCII strings, and hex headers.
- `extract-art-dat.py` — parses SSI chunk-based `.DAT` files (`Indx` TOC + `RLEi`
  RLE-encoded indexed bitmaps + `CPal` palettes) and writes one PNG per sprite.
- `build-icon-picker.py` + `icon-picker.html` — generates a self-contained HTML
  gallery of all extracted sprites (per size) with click-to-assign workflow and a
  shell-command exporter.

See [tools/README.md](tools/README.md).

---

## Legacy `PGEdit/` (WinForms)

Preserved unchanged. Build with Visual Studio 2012 + .NET Framework 4.5, or
run the pre-built binary at `PGEdit/prebuilt/PGEdit.exe`.

---

## Author

Chun-Yu Wang (wicanr2@gmail.com)
