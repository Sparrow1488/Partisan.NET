using System.Windows.Controls;
using System.Windows.Input;
using PartisanNET.Modules.Identity.Contracts;
using PartisanNET.Modules.Identity.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace PartisanNET.App.Wpf.ViewModels;

public class LoginViewModel : BindableBase
{
    private readonly IIdentityService _identityService;
    private string? _login;
    private DelegateCommand<PasswordBox>? _loginCommand;

    public LoginViewModel(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public ICommand LoginCommand => _loginCommand ??= new DelegateCommand<PasswordBox>(box =>
    {
        _identityService.AuthenticateAsync(new LoginCredentials(Login, box.Password)).ConfigureAwait(false);
    });

    public string? Login
    {
        get => _login;
        set => SetProperty(ref _login, value);
    }
}