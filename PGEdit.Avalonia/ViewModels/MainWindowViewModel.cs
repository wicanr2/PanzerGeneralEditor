using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PGEdit.Avalonia.Models;
using PGEdit.Avalonia.Services;
using PGEdit.Avalonia.Views;

namespace PGEdit.Avalonia.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly EquipmentFileService _file = new();
    private readonly BackupService _backup = new();
    private readonly UndoRedoService _history = new();

    public ObservableCollection<UnitListItemViewModel> Units { get; } = new();

    [ObservableProperty] private string? _filePath;
    [ObservableProperty] private string _searchQuery = string.Empty;
    [ObservableProperty] private UnitListItemViewModel? _selectedUnit;
    [ObservableProperty] private UnitEditorViewModel _editor = new();
    [ObservableProperty] private string _statusMessage = "尚未開啟檔案。File ▸ Open 載入 PANZEQUP.EQP";
    [ObservableProperty] private string? _backupNotice;

    public IEnumerable<UnitListItemViewModel> FilteredUnits =>
        string.IsNullOrWhiteSpace(SearchQuery)
            ? Units
            : Units.Where(u =>
                u.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
                || u.TypeName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

    public bool HasFile => !string.IsNullOrEmpty(FilePath);
    public bool CanSave => Editor.IsDirty && HasFile;
    public bool CanUndo => _history.CanUndo;
    public bool CanRedo => _history.CanRedo;

    public MainWindowViewModel()
    {
        Editor.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(UnitEditorViewModel.IsDirty))
            {
                OnPropertyChanged(nameof(CanSave));
                UpdateStatus();
            }
        };
    }

    [RelayCommand]
    private async Task OpenAsync()
    {
        var window = TopLevel();
        if (window is null) return;

        var files = await window.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "選擇 PANZEQUP.EQP",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("Panzer General Equipment (*.EQP)")
                {
                    Patterns = new[] { "*.EQP", "*.eqp" },
                },
                FilePickerFileTypes.All,
            },
        });
        var picked = files.FirstOrDefault();
        if (picked?.Path.LocalPath is not { } path) return;

        LoadFile(path);
    }

    public void LoadFile(string path)
    {
        var list = _file.Open(path);
        FilePath = path;
        Units.Clear();
        foreach (var u in list)
        {
            Units.Add(new UnitListItemViewModel
            {
                Index = u.Index,
                Name = u.Name,
                Type = u.Type,
            });
        }
        OnPropertyChanged(nameof(FilteredUnits));
        OnPropertyChanged(nameof(HasFile));

        _backup.Reset();
        _history.Clear();
        OnPropertyChanged(nameof(CanUndo));
        OnPropertyChanged(nameof(CanRedo));

        SelectedUnit = Units.FirstOrDefault();
        StatusMessage = $"已載入 {Units.Count} 個單位 · {Path.GetFileName(path)}";
    }

    partial void OnSearchQueryChanged(string value) => OnPropertyChanged(nameof(FilteredUnits));

    partial void OnSelectedUnitChanged(UnitListItemViewModel? value)
    {
        if (value is null) return;
        var dto = _file.ReadOne(value.Index);
        Editor.Load(dto);
        OnPropertyChanged(nameof(CanSave));
        UpdateStatus();
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        if (SelectedUnit is null || FilePath is null) return;

        var before = _file.ReadOne(Editor.Index);
        var after = Editor.ToDto();

        IReadOnlyList<DiffRow> diff = DiffDialog.BuildDiff(before, after);
        if (diff.Count == 0)
        {
            StatusMessage = "沒有變更可儲存。";
            return;
        }

        var owner = TopLevel() as Window;
        var dlg = new DiffDialog();
        dlg.Load(diff);
        if (owner is not null) await dlg.ShowDialog(owner);
        else dlg.Show();
        if (!dlg.Confirmed)
        {
            StatusMessage = "已取消儲存。";
            return;
        }

        var bakPath = _backup.CreateIfFirstTime(FilePath);
        if (bakPath is not null)
            BackupNotice = $"已建立備份 → {Path.GetFileName(bakPath)}";

        _file.WriteBack(after);
        _history.Push(new UndoRedoService.Entry(Editor.Index, before, after));

        // refresh list row in case name changed
        SelectedUnit.Name = after.Name;

        // re-read to absorb cost rounding (12 倍數)
        var refreshed = _file.ReadOne(Editor.Index);
        Editor.Load(refreshed);

        OnPropertyChanged(nameof(CanUndo));
        OnPropertyChanged(nameof(CanRedo));
        OnPropertyChanged(nameof(CanSave));
        StatusMessage = $"已儲存 #{after.Index:D3} {after.Name}";
    }

    [RelayCommand(CanExecute = nameof(CanUndo))]
    private void Undo()
    {
        var e = _history.Undo();
        if (e is null) return;
        _file.WriteBack(e.Before);
        if (SelectedUnit?.Index == e.Index)
            Editor.Load(_file.ReadOne(e.Index));
        OnPropertyChanged(nameof(CanUndo));
        OnPropertyChanged(nameof(CanRedo));
        StatusMessage = $"已復原 #{e.Index:D3}";
    }

    [RelayCommand(CanExecute = nameof(CanRedo))]
    private void Redo()
    {
        var e = _history.Redo();
        if (e is null) return;
        _file.WriteBack(e.After);
        if (SelectedUnit?.Index == e.Index)
            Editor.Load(_file.ReadOne(e.Index));
        OnPropertyChanged(nameof(CanUndo));
        OnPropertyChanged(nameof(CanRedo));
        StatusMessage = $"已重做 #{e.Index:D3}";
    }

    [RelayCommand]
    private void Prev()
    {
        if (Units.Count == 0 || SelectedUnit is null) return;
        var i = Units.IndexOf(SelectedUnit);
        SelectedUnit = Units[(i - 1 + Units.Count) % Units.Count];
    }

    [RelayCommand]
    private void Next()
    {
        if (Units.Count == 0 || SelectedUnit is null) return;
        var i = Units.IndexOf(SelectedUnit);
        SelectedUnit = Units[(i + 1) % Units.Count];
    }

    private void UpdateStatus()
    {
        if (!HasFile) return;
        var dirty = Editor.IsDirty ? " · 未儲存變更" : "";
        StatusMessage = $"#{Editor.Index:D3} {Editor.Name}{dirty}";
    }

    private static TopLevel? TopLevel()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime d)
            return d.MainWindow;
        return null;
    }
}
