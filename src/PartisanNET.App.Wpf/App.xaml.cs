using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PartisanNET.App.Wpf.Constants;
using PartisanNET.App.Wpf.Services;
using PartisanNET.App.Wpf.Views;
using Prism.Ioc;
using Prism.Microsoft.DependencyInjection;

namespace PartisanNET.App.Wpf;

public partial class App
{
    protected override Window CreateShell() => Container.Resolve<ShellWindow>();

    protected override IContainerExtension CreateContainerExtension()
    {
        var services = new ServiceCollection();
        
        ConfigureServices(services);
        PrismContainerExtension.Init(services);

        return base.CreateContainerExtension();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<GreetingService>();
    }

    protected override void RegisterTypes(IContainerRegistry container)
    {
        container.RegisterForNavigation<GreetingView>(Regions.GreetingRegion);
        container.RegisterForNavigation<WarriorView>(Regions.WarriorRegion);
    }
}