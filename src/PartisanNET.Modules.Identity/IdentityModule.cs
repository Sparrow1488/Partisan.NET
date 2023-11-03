using PartisanNET.Modules.Identity.Contracts;
using PartisanNET.Modules.Identity.Models;
using PartisanNET.Modules.Identity.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace PartisanNET.Modules.Identity;

public class IdentityModule : IModule
{
    public void RegisterTypes(IContainerRegistry registry)
    {
        registry.RegisterSingleton<IUserSession, UserSession>();
        registry.RegisterSingleton<IIdentityService, TestIdentityService>();
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        
    }
}