using System.Windows.Input;
using PartisanNET.App.Wpf.Views;
using PartisanNET.Core.Wpf.Navigation;
using Prism.Commands;
using Prism.Mvvm;

#region Annotations

// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace PartisanNET.App.Wpf.ViewModels;

public class GreetingViewModel : BindableBase
{
    private readonly NavigationService<MainViewModel> _navigationService;
    private ICommand? _login;

    public GreetingViewModel(NavigationStore store)
    {
        _navigationService = store.GetRequiredNavigation<MainViewModel>();
    }

    public ICommand Login => _login ??= new DelegateCommand(() =>
    {
        _navigationService.Navigate<WarriorView>();
    });
}