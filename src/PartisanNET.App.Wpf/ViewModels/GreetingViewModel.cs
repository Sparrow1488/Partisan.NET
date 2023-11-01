using System.Windows.Input;
using PartisanNET.App.Wpf.Services;
using Prism.Commands;
using Prism.Mvvm;

#region Annotations

// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace PartisanNET.App.Wpf.ViewModels;

public class GreetingViewModel : BindableBase
{
    private readonly GreetingService _greetingService;
    private ICommand? _login;
    private string? _greetingMessage;

    public GreetingViewModel(GreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public string? GreetingMessage
    {
        get => _greetingMessage;
        set => SetProperty(ref _greetingMessage, value);
    }

    public ICommand Login => _login ??= new DelegateCommand(() =>
    {
        GreetingMessage = _greetingService.GetMessage();
    });
}