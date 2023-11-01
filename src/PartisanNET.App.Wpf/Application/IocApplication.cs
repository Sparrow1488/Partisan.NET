using Microsoft.Extensions.DependencyInjection;
using Prism;
using Prism.Ioc;
using Prism.Microsoft.DependencyInjection;
using Prism.Unity;

namespace PartisanNET.App.Wpf.Application;

public abstract class IocApplication : PrismApplication
{
    protected abstract void ConfigureServices(IServiceCollection services);

    protected override IContainerExtension CreateContainerExtension()
    {
        var services = new ServiceCollection();
        
        ConfigureServices(services);
        
        return new PrismContainerExtension(services);
    }

    // private IHost CreateApplicationHost()
    // {
        // var builder = Host.CreateDefaultBuilder();
        // builder.ConfigureServices(ConfigureServices);
        //
        // builder.ConfigureServices(s =>
        // {
        //     s.AddSingleton<NavigationMaps>(_ =>
        //     {
        //         var maps = new NavigationMaps();
        //         ConfigureViews(maps);
        //
        //         return maps;
        //     });
        //     
        //     var maps = new NavigationMaps();
        //     ConfigureViews(maps);
        //     
        //     s.AddSingleton<NavigationStore>();
        //     s.AddScoped(typeof(NavigationService<>));
        // });
        //
        // builder.ConfigureServices(x => PrismContainerExtension.Init(x));
        //
        // return builder.Build();
    // }
}