#!/usr/bin/env bash
# Docker build for PGEdit.Avalonia.
# 從 PanzerGeneralEditor/ repo 根目錄執行;或在本目錄執行也可。
set -euo pipefail

cd "$(dirname "$0")"
ROOT="$(cd .. && pwd)"

RID="${1:-linux-x64}"
OUT_DIR="${2:-./out/$RID}"

echo "→ Restoring + publishing for RID=$RID → $OUT_DIR"

docker run --rm \
    -v "$ROOT":/src \
    -w /src/PGEdit.Avalonia \
    -u "$(id -u):$(id -g)" \
    -e DOTNET_CLI_HOME=/tmp \
    -e HOME=/tmp \
    mcr.microsoft.com/dotnet/sdk:8.0 \
    dotnet publish -c Release -r "$RID" --self-contained \
                   -p:PublishSingleFile=true \
                   -p:IncludeNativeLibrariesForSelfExtract=true \
                   -o "$OUT_DIR"

echo "✔ Done. Binary at PGEdit.Avalonia/$OUT_DIR/PGEdit.Avalonia"
