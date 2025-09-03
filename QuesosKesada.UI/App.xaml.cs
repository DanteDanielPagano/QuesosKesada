using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace QuesosKesada.UI;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServicesProvider { get; private set; }

    public App()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        ServicesProvider = serviceCollection.BuildServiceProvider();
    }
}

