using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
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
    private readonly IDialogCoordinator _coordinator;
    private readonly ShellWindowResolver _windowResolver;
    private ICommand? _login;
    private string? _greetingMessage;

    public GreetingViewModel(
        GreetingService greetingService, 
        ShellWindowResolver windowResolver)
    {
        _greetingService = greetingService;
        _coordinator = DialogCoordinator.Instance;
        _windowResolver = windowResolver;
    }

    public string? GreetingMessage
    {
        get => _greetingMessage;
        set => SetProperty(ref _greetingMessage, value);
    }

    public ICommand Login => _login ??= new DelegateCommand(async () =>
    {
        var settings = new MetroDialogSettings
        {
            AnimateHide = false,
            AnimateShow = false
        };
        
        var dialogResult = await _coordinator.ShowLoginAsync(_windowResolver.Window!.DataContext, "Login", "Message");
        
        // GreetingMessage = _greetingService.GetMessage();
    });
}