using Avalonia;
using System;
using WmiLight;

namespace WmiLightAOT;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        using var wmiConnection = new WmiConnection("root\\cimv2");

        var mos = wmiConnection.CreateQuery(
            "SELECT Name, NumberOfCores, SocketDesignation FROM Win32_Processor");
        var firstLine = true;
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}