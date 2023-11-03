using System.Windows;
using PartisanNET.App.Wpf.Constants;
using PartisanNET.App.Wpf.ViewModels;
using PartisanNET.App.Wpf.Views;
using PartisanNET.Modules.Dialogs;
using PartisanNET.Modules.Identity;
using Prism.Ioc;
using Prism.Modularity;

namespace PartisanNET.App.Wpf;

public partial class App
{
    protected override Window CreateShell() => Container.Resolve<ShellWindow>();

    protected override void RegisterTypes(IContainerRegistry registry)
    {
        registry.RegisterForNavigation<ShellWindow, ShellWindowViewModel>();
        registry.RegisterForNavigation<GreetingView>(Regions.GreetingRegion);
        registry.RegisterForNavigation<WarriorView>(Regions.WarriorRegion);
        registry.RegisterForNavigation<LoginView>(Regions.LoginRegion);
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<DialogsModule>();
        moduleCatalog.AddModule<IdentityModule>();
    }
}