using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PGEdit.Avalonia.Models;

namespace PGEdit.Avalonia.Views;

public partial class DiffDialog : Window
{
    public DiffDialog()
    {
        InitializeComponent();
    }

    public static IReadOnlyList<DiffRow> BuildDiff(UnitDto before, UnitDto after)
    {
        var rows = new List<DiffRow>();
        void Add<T>(string field, T b, T a)
        {
            if (!EqualityComparer<T>.Default.Equals(b, a))
                rows.Add(new DiffRow(field, b?.ToString() ?? "", a?.ToString() ?? ""));
        }
        Add("名稱", before.Name, after.Name);
        Add("柔性攻擊", before.SoftAttack, after.SoftAttack);
        Add("硬性攻擊", before.HardAttack, after.HardAttack);
        Add("對空攻擊", before.AirAttack, after.AirAttack);
        Add("對海攻擊", before.NavalAttack, after.NavalAttack);
        Add("對地防禦", before.GroundDefense, after.GroundDefense);
        Add("對空防禦", before.AirDefense, after.AirDefense);
        Add("近戰防禦", before.CloseDefense, after.CloseDefense);
        Add("啟動值", before.Initiative, after.Initiative);
        Add("攻擊範圍", before.Range, after.Range);
        Add("偵查範圍", before.Spotting, after.Spotting);
        Add("移動量", before.Movement, after.Movement);
        Add("油量", before.Fuel, after.Fuel);
        Add("彈藥", before.Ammunition, after.Ammunition);
        Add("價格", before.Cost, after.Cost);
        Add("壓制力", before.LevelPression, after.LevelPression);
        Add("初始兵力", before.InitForce, after.InitForce);
        return rows;
    }

    public bool Confirmed { get; private set; }

    public void Load(IReadOnlyList<DiffRow> rows)
    {
        var list = this.FindControl<ItemsControl>("DiffList");
        if (list is not null) list.ItemsSource = rows;
    }

    private void OnConfirm(object? sender, RoutedEventArgs e)
    {
        Confirmed = true;
        Close();
    }

    private void OnCancel(object? sender, RoutedEventArgs e)
    {
        Confirmed = false;
        Close();
    }
}
