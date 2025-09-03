using Microsoft.AspNetCore.Components.WebView;
using Microsoft.Web.WebView2.Core;
using System.Windows;

namespace QuesosKesada.UI;
public partial class MainWindow : Window
{
    private CoreWebView2 _core;
    public MainWindow()
    {
        InitializeComponent();
        BlazorHost.BlazorWebViewInitialized += OnBlazorWebViewInitialized;

    }
    private void OnBlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e)
    {
        // Si CoreWebView2 ya existe, úsalo directamente…
        if (e.WebView.CoreWebView2 != null)
        {
            _core = e.WebView.CoreWebView2;
            _core.OpenDevToolsWindow();
        }
        else
        {
            // …o espera a que termine de inicializarse
            e.WebView.CoreWebView2InitializationCompleted += (s, args) =>
            {
                if (args.IsSuccess)
                {
                    // 's' aquí es el CoreWebView2 mismo
                    _core = (CoreWebView2)s;
                    _core.OpenDevToolsWindow();
                }
            };
        }
    }
}