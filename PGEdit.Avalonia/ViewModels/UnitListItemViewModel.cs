using CommunityToolkit.Mvvm.ComponentModel;
using PGEdit.Avalonia.Models;

namespace PGEdit.Avalonia.ViewModels;

/// <summary>
/// 左側清單的單筆 row;Name 會跟著編輯區同步,Category 用於 group by。
/// </summary>
public partial class UnitListItemViewModel : ObservableObject
{
    [ObservableProperty] private int _index;
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private UnitType _type;

    public string Glyph => UnitTypeRegistry.Glyph(Type);
    public string Category => UnitTypeRegistry.Category(Type);
    public string TypeName => UnitTypeRegistry.DisplayName(Type);
}
