#!/usr/bin/env bash
# 產出 Windows release artifacts:zip + 7z SFX self-extracting installer
# 從 repo 根目錄執行:./PGEdit.Avalonia/make-release.sh
#
# 需要工具:
#   - docker (做 .NET 8 publish)
#   - 7z, zip, curl (打包)
#   - 第一次跑會自動從 https://www.7-zip.org/ 抓 Windows SFX module 到 .cache/
set -euo pipefail

cd "$(dirname "$0")/.."
ROOT="$PWD"
VERSION="1.0.0-$(date +%Y%m%d)"
CACHE="$ROOT/.cache"
mkdir -p "$CACHE" dist

# ---- Step 1: Windows x64 self-contained publish ----
echo "→ publishing win-x64 self-contained single-file…"
./PGEdit.Avalonia/docker-build.sh win-x64 >/dev/null
WINEXE="$ROOT/PGEdit.Avalonia/out/win-x64/PGEdit.Avalonia.exe"
[ -f "$WINEXE" ] || { echo "publish failed"; exit 1; }
ls -lh "$WINEXE"

# ---- Step 2: stage with bundled README ----
STAGE=$(mktemp -d)
trap "rm -rf $STAGE" EXIT
cp "$WINEXE" "$STAGE/"
cat > "$STAGE/README.txt" <<EOF
裝甲元帥編輯器 (PGEdit.Avalonia) — Windows x64
版本:$VERSION

使用方法
========
1. 雙擊 PGEdit.Avalonia.exe 啟動 (Windows 10/11 x64,免安裝 .NET)
2. File ▸ Open (或 Ctrl+O) 載入 PANZEQUP.EQP
3. 修改任何欄位後 Ctrl+S 儲存,會跳 Diff 對話框確認
4. 首次儲存會自動建立 timestamped .bak 備份

快捷鍵
======
Ctrl+O   開啟 .EQP
Ctrl+S   儲存
Ctrl+Z   復原
Ctrl+Y   重做
Up/Down  上/下一個單位

支援
=====
GitHub: https://github.com/wicanr2/PanzerGeneralEditor
Author: Chun-Yu Wang (wicanr2@gmail.com)
EOF

# ---- Step 3: zip ----
ZIPOUT="dist/PGEdit.Avalonia-${VERSION}-win-x64.zip"
rm -f "$ZIPOUT"
( cd "$STAGE" && zip -9 -r "$ROOT/$ZIPOUT" . ) >/dev/null
echo "→ zip: $ZIPOUT ($(du -h "$ZIPOUT" | cut -f1))"

# ---- Step 4: fetch Windows SFX module (cached) ----
SFXMOD="$CACHE/7z.sfx"
if [ ! -f "$SFXMOD" ]; then
    echo "→ downloading 7-Zip Windows SFX module…"
    TMP_DL="$CACHE/7z2301-x64.exe"
    curl -fsSL -o "$TMP_DL" https://www.7-zip.org/a/7z2301-x64.exe
    7z e "$TMP_DL" -o"$CACHE" 7z.sfx 7zCon.sfx >/dev/null
    rm -f "$TMP_DL"
fi
[ -f "$SFXMOD" ] || { echo "SFX module fetch failed"; exit 1; }

# ---- Step 5: SFX config (UTF-8 BOM) ----
SFXCFG=$(mktemp)
printf '\xef\xbb\xbf' > "$SFXCFG"
cat >> "$SFXCFG" <<'EOF'
;!@Install@!UTF-8!
Title="裝甲元帥編輯器 PGEdit.Avalonia"
BeginPrompt="解壓 PGEdit.Avalonia 到目前目錄,並啟動?"
ExtractTitle="解壓中..."
ExtractDialogText="正在解壓 PGEdit.Avalonia.exe..."
ExtractCancelText="取消"
RunProgram="PGEdit.Avalonia.exe"
;!@InstallEnd@!
EOF

# ---- Step 6: 7z payload + cat SFX ----
PAYLOAD=$(mktemp --suffix=.7z)
rm -f "$PAYLOAD"
( cd "$STAGE" && 7z a -mx=9 "$PAYLOAD" PGEdit.Avalonia.exe README.txt ) >/dev/null
SFXOUT="dist/PGEdit.Avalonia-${VERSION}-win-x64-setup.exe"
cat "$SFXMOD" "$SFXCFG" "$PAYLOAD" > "$ROOT/$SFXOUT"
chmod +x "$ROOT/$SFXOUT"
rm -f "$SFXCFG" "$PAYLOAD"

echo ""
echo "→ SFX: $SFXOUT ($(du -h "$SFXOUT" | cut -f1))"
echo ""
echo "=== Done ==="
ls -lh dist/
sha256sum dist/PGEdit.Avalonia-${VERSION}-win-x64*
