using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PartisanNET.Core.Wpf.Navigation;

namespace PartisanNET.App.Wpf.Application;

public abstract class IocApplication : System.Windows.Application
{
    protected IocApplication()
    {
        var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder();
        host.ConfigureServices(ConfigureServices);

        host.ConfigureServices(s 
            => s.AddScoped<NavigationService>(provider =>
            {
                var builder = ActivatorUtilities.CreateInstance<NavigationServiceBuilder>(provider);
                ConfigureViews(builder);

                return builder.Build();
            }));
        
        Host = host.Build();
        Services = Host.Services;
        Navigation = Services.GetRequiredService<NavigationService>();
    }

    protected IHost Host { get; }
    protected IServiceProvider Services { get; }
    protected NavigationService Navigation { get; }
    
    protected abstract void ConfigureViews(NavigationServiceBuilder nav);
    protected abstract void ConfigureServices(IServiceCollection services);
    protected abstract Window ResolveMainWindow(IServiceProvider services, NavigationService navigation);

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = ResolveMainWindow(Services, Navigation);
        
        base.OnStartup(e);

        MainWindow.Show();
    }
}