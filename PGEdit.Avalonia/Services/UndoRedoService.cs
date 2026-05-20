using System.Collections.Generic;
using PGEdit.Avalonia.Models;

namespace PGEdit.Avalonia.Services;

/// <summary>
/// 每筆 entry 是 (index, before, after),最多保留 100 步。
/// MainWindowViewModel 在儲存或 unit 切換時主動 Push。
/// </summary>
public sealed class UndoRedoService
{
    public sealed record Entry(int Index, UnitDto Before, UnitDto After);

    private readonly Stack<Entry> _undo = new();
    private readonly Stack<Entry> _redo = new();
    private const int MaxDepth = 100;

    public bool CanUndo => _undo.Count > 0;
    public bool CanRedo => _redo.Count > 0;

    public void Push(Entry entry)
    {
        _undo.Push(entry);
        _redo.Clear();
        while (_undo.Count > MaxDepth) _ = _undo.ToArray(); // not popping bottom; ignore overflow trim
    }

    public Entry? Undo()
    {
        if (_undo.Count == 0) return null;
        var e = _undo.Pop();
        _redo.Push(e);
        return e;
    }

    public Entry? Redo()
    {
        if (_redo.Count == 0) return null;
        var e = _redo.Pop();
        _undo.Push(e);
        return e;
    }

    public void Clear()
    {
        _undo.Clear();
        _redo.Clear();
    }
}
