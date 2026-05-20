using System;
using System.Collections.Concurrent;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PGEdit.Avalonia.Models;

namespace PGEdit.Avalonia.Services;

/// <summary>
/// PG 真實機制:EQP byte 42 (`_little_icon`) 是 0..255 byte,直接 index 進
/// TILEART.DAT u### sprite (256 個 hex unit silhouette)。
///
/// 例如 BF109e._little_icon = 1 → 載入 Assets/units/u001.png (戰機 silhouette)。
/// </summary>
public static class UnitIconProvider
{
    private static readonly ConcurrentDictionary<int, Bitmap?> Cache = new();

    public static Bitmap? GetByLittleIcon(int littleIcon)
    {
        return Cache.GetOrAdd(littleIcon, idx =>
        {
            try
            {
                var uri = new Uri($"avares://PGEdit.Avalonia/Assets/units/u{idx:D3}.png");
                using var stream = AssetLoader.Open(uri);
                return new Bitmap(stream);
            }
            catch
            {
                return null;
            }
        });
    }

    public static bool HasLittleIcon(int littleIcon) =>
        GetByLittleIcon(littleIcon) is not null;
}
