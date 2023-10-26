using System;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using PartisanNET.App.Wpf.Services;
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
    private readonly GreetingService _greetingService;
    private readonly NavigationService _navigationService;
    private ICommand? _login;

    public GreetingViewModel(IServiceProvider services)
    {
        _greetingService = services.GetRequiredService<GreetingService>();
        _navigationService = services.GetRequiredService<NavigationService>();
    }

    public string Text => _greetingService.GetMessage();

    public ICommand Login => _login ??= new DelegateCommand(() =>
    {
        _navigationService.Navigate<WarriorView>();
    });
}