using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PartisanNET.App.Wpf.Services;
using PartisanNET.App.Wpf.ViewModels;
using PartisanNET.App.Wpf.Views;

namespace PartisanNET.App.Wpf;

public partial class App
{
    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<GreetingService>();
    }

    protected override Window ResolveMainWindow(IServiceProvider services)
        => services.GetRequiredService<MainWindow>();
}