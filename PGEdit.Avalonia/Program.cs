using System;
using System.Text;
using Avalonia;

namespace PGEdit.Avalonia;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        // PGEQReader 使用 CP950 (Big5) 解析單位名稱;.NET 8 預設不含此 codepage。
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
