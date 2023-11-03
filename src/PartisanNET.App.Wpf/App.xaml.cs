using System.Windows;
using PartisanNET.App.Wpf.Constants;
using PartisanNET.App.Wpf.Services;
using PartisanNET.App.Wpf.ViewModels;
using PartisanNET.App.Wpf.Views;
using PartisanNET.Modules.Dialogs;
using Prism.Ioc;
using Prism.Modularity;

namespace PartisanNET.App.Wpf;

public partial class App
{
    protected override Window CreateShell() => Container.Resolve<ShellWindow>();

    protected override void RegisterTypes(IContainerRegistry registry)
    {
        registry.RegisterSingleton<GreetingService>();

        registry.RegisterForNavigation<ShellWindow, ShellWindowViewModel>();
        registry.RegisterForNavigation<GreetingView>(Regions.GreetingRegion);
        registry.RegisterForNavigation<WarriorView>(Regions.WarriorRegion);
        
        // registry.RegisterSingleton<IDialogServiceAdapter, DialogServiceAdapter>();
        // registry.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
        // registry.RegisterSingleton<ShellWindowResolver>(() => new ShellWindowResolver(Application.Current.MainWindow));
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<DialogsModule>();
    }
}