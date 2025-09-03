using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace QuesosKesada.UI.WPF;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
}

