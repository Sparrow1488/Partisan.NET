using System.Windows.Input;
using PartisanNET.App.Wpf.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

#region Annotations

// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace PartisanNET.App.Wpf.ViewModels;

public class ShellWindowViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;

    public ShellWindowViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public ICommand Navigate => new DelegateCommand(() =>
    {
        var navigation = _regionManager.Regions[Regions.MainRegion].NavigationService;
        navigation.RequestNavigate(Regions.GreetingRegion);
    });
}