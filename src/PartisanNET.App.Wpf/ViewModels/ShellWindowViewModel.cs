using System.Windows.Input;
using PartisanNET.App.Wpf.Constants;
using PartisanNET.Modules.Dialogs.Contracts;
using PartisanNET.Modules.Dialogs.Services;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

#region Annotations

// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace PartisanNET.App.Wpf.ViewModels;

public class ShellWindowViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;
    private readonly IContainerProvider _container;

    public ShellWindowViewModel(IRegionManager regionManager, IContainerProvider container)
    {
        _regionManager = regionManager;
        _container = container;
    }

    public ICommand Navigate => new DelegateCommand(() =>
    {
        var dialogService = _container.Resolve<IDialogServiceAdapter>();
        dialogService.ShowDialog(Regions.GreetingRegion, null);

        // var navigation = _regionManager.Regions[Regions.MainRegion].NavigationService;
        // navigation.RequestNavigate(Regions.GreetingRegion);
    });
}