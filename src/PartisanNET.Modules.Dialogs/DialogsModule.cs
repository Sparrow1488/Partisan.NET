using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using PartisanNET.Modules.Dialogs.Contracts;
using PartisanNET.Modules.Dialogs.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace PartisanNET.Modules.Dialogs;

public class DialogsModule : IModule
{
    public void RegisterTypes(IContainerRegistry registry)
    {
        registry.RegisterSingleton<ShellWindowResolver>(() => new ShellWindowResolver(Application.Current.MainWindow));
        registry.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
        registry.RegisterSingleton<IDialogServiceAdapter, DialogServiceAdapter>();
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        
    }
}