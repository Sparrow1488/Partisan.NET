using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PartisanNET.App.Wpf.Application;

public abstract class IocApplication : System.Windows.Application
{
    protected IocApplication()
    {
        var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder();
        host.ConfigureServices(ConfigureServices);

        Host = host.Build();
        Services = Host.Services;
    }

    protected IHost Host { get; }
    protected IServiceProvider Services { get; }
    
    protected abstract void ConfigureServices(IServiceCollection services);
    protected abstract Window ResolveMainWindow(IServiceProvider services);

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = ResolveMainWindow(Services);
        
        base.OnStartup(e);
        
        MainWindow.Show();
    }
}