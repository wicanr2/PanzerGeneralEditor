using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using PGEdit.Avalonia.ViewModels;

namespace PGEdit.Avalonia.Controls;

/// <summary>
/// 7 軸雷達圖:soft / hard / air / naval attack + ground / air / close defense。
/// 直接讀 DataContext (UnitEditorViewModel),不另開 DP,免去 binding 樣板。
/// </summary>
public sealed class StatRadarChart : Control
{
    private const int Axes = 7;
    private const double Max = 25;          // 軟上限,符合「建議 ≤ 25」
    private static readonly string[] Labels =
    {
        "柔攻", "硬攻", "空攻", "海攻", "地防", "空防", "近防"
    };

    public StatRadarChart()
    {
        DataContextChanged += OnDataCtxChanged;
    }

    private void OnDataCtxChanged(object? sender, EventArgs e)
    {
        if (DataContext is INotifyPropertyChanged vm)
            vm.PropertyChanged += (_, _) => InvalidateVisual();
        InvalidateVisual();
    }

    public override void Render(DrawingContext ctx)
    {
        base.Render(ctx);

        var w = Bounds.Width;
        var h = Bounds.Height;
        if (w <= 0 || h <= 0) return;

        var cx = w / 2;
        var cy = h / 2;
        var radius = Math.Min(w, h) / 2 - 28;
        if (radius <= 0) return;

        var grid = TryBrush("OutlineBrush", Brushes.Gray);
        var fill = TryBrush("AccentBrush", Brushes.Goldenrod);
        var text = TryBrush("TextMutedBrush", Brushes.Gainsboro);
        var fillPen = new Pen(fill, 2);
        var gridPen = new Pen(grid, 0.75);

        // grid rings
        for (var ring = 1; ring <= 5; ring++)
        {
            var r = radius * ring / 5.0;
            var p = BuildPolygon(cx, cy, r, _ => 1.0);
            ctx.DrawGeometry(null, gridPen, p);
        }

        // axes + labels
        var ft = new Typeface("Inter, Noto Sans TC, Microsoft JhengHei");
        for (var i = 0; i < Axes; i++)
        {
            var (sin, cos) = AxisVec(i);
            var ex = cx + sin * radius;
            var ey = cy - cos * radius;
            ctx.DrawLine(gridPen, new Point(cx, cy), new Point(ex, ey));

            var lx = cx + sin * (radius + 16);
            var ly = cy - cos * (radius + 16);
            var ftext = new FormattedText(Labels[i], System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, ft, 11, text);
            ctx.DrawText(ftext, new Point(lx - ftext.Width / 2, ly - ftext.Height / 2));
        }

        // values
        if (DataContext is not UnitEditorViewModel vm) return;
        var values = new double[]
        {
            vm.SoftAttack, vm.HardAttack, vm.AirAttack, vm.NavalAttack,
            vm.GroundDefense, vm.AirDefense, vm.CloseDefense,
        };

        var dataPoly = BuildPolygon(cx, cy, radius, i => Math.Clamp(values[i] / Max, 0, 1));
        var fillColor = fill is ISolidColorBrush scb ? scb.Color : Colors.Goldenrod;
        ctx.DrawGeometry(new SolidColorBrush(fillColor, 0.25), fillPen, dataPoly);
    }

    private IBrush TryBrush(string key, IBrush fallback)
    {
        if (this.TryFindResource(key, ActualThemeVariant, out var v) && v is IBrush b)
            return b;
        if (Application.Current is { } app
            && app.TryGetResource(key, app.ActualThemeVariant, out var appV) && appV is IBrush ab)
            return ab;
        return fallback;
    }

    private static (double sin, double cos) AxisVec(int i)
    {
        var theta = 2 * Math.PI * i / Axes;
        return (Math.Sin(theta), Math.Cos(theta));
    }

    private static StreamGeometry BuildPolygon(double cx, double cy, double radius, Func<int, double> scale)
    {
        var g = new StreamGeometry();
        using var ctx = g.Open();
        for (var i = 0; i < Axes; i++)
        {
            var (sin, cos) = AxisVec(i);
            var s = scale(i) * radius;
            var pt = new Point(cx + sin * s, cy - cos * s);
            if (i == 0) ctx.BeginFigure(pt, true);
            else ctx.LineTo(pt);
        }
        ctx.EndFigure(true);
        return g;
    }
}
