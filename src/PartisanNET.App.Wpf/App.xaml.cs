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

    protected override Window ResolveMainWindow(IServiceProvider services)
    {
        return services.GetRequiredService<MainWindow>();
    }

    protected override void ConfigureViews(NavigationMaps maps)
    {
        maps.AddNavigation<GreetingView, GreetingViewModel>();
        maps.AddNavigation<WarriorView, WarriorViewModel>();
        maps.AddNavigation<SquadView, SquadViewModel>();
        maps.AddNavigation<GlobalTopView, GlobalTopViewModel>();
    }
}