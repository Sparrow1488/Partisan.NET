using System.Windows.Input;
using PartisanNET.App.Wpf.Views;
using PartisanNET.Core.Wpf.Navigation;
using Prism.Commands;

namespace PartisanNET.App.Wpf.ViewModels;

public class GlobalTopViewModel
{
    private readonly NavigationService<MainViewModel> _mainNavigation;
    private DelegateCommand? _goHome;
    private DelegateCommand? _goWarrior;

    public GlobalTopViewModel(NavigationStore store)
    {
        _mainNavigation = store.GetRequiredNavigation<MainViewModel>();
    }

    public ICommand GoHome => _goHome ??= new DelegateCommand(() =>
    {
        _mainNavigation.NavigateRequest<GreetingView>();
    });
    
    public ICommand GoWarrior => _goWarrior ??= new DelegateCommand(() =>
    {
        _mainNavigation.NavigateRequest<WarriorView>();
    });
}