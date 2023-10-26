using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PartisanNET.App.Wpf.Services;
using PartisanNET.App.Wpf.ViewModels;
using PartisanNET.App.Wpf.Views;
using PartisanNET.Core.Wpf.Navigation;

namespace PartisanNET.App.Wpf;

public partial class App
{
    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<GreetingService>();

        #region Костыль с регистрацией View

        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainViewModel>();

        #endregion
    }

    protected override Window ResolveMainWindow(IServiceProvider services, NavigationService navigation)
    {
        return services.GetRequiredService<MainWindow>();
    }

    protected override void ConfigureViews(NavigationServiceBuilder nav)
    {
        nav.AddNavigation<GreetingView, GreetingViewModel>();
        nav.AddNavigation<WarriorView, WarriorViewModel>();
        nav.AddNavigation<SquadView, SquadViewModel>();
    }
}