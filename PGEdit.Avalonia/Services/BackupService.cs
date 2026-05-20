using System;
using System.IO;

namespace PGEdit.Avalonia.Services;

/// <summary>
/// 第一次儲存前複製一份 timestamped .bak,避免 PANZEQUP.EQP 改壞了沒退路。
/// 每次開檔重新計算,同一個 process 內第一次寫回會觸發。
/// </summary>
public sealed class BackupService
{
    private string? _lastBackedUpPath;

    public string? CreateIfFirstTime(string path)
    {
        if (_lastBackedUpPath == path) return null;
        if (!File.Exists(path)) return null;

        var stamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
        var backupPath = $"{path}.{stamp}.bak";

        File.Copy(path, backupPath, overwrite: false);
        _lastBackedUpPath = path;
        return backupPath;
    }

    public void Reset() => _lastBackedUpPath = null;
}
