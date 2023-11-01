using System.Windows;
using PartisanNET.App.Wpf.Constants;
using PartisanNET.App.Wpf.Services;
using PartisanNET.App.Wpf.Views;
using Prism.Ioc;

namespace PartisanNET.App.Wpf;

public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<ShellWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<GreetingService>();
     
        containerRegistry.RegisterForNavigation<GreetingView>(Regions.GreetingRegion);
    }
}