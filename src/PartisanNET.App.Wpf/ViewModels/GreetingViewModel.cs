using System;
using System.Windows.Input;
using PartisanNET.App.Wpf.Constants;
using PartisanNET.Modules.Dialogs.Contracts;
using PartisanNET.Modules.Identity.Contracts;
using PartisanNET.Modules.Identity.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

#region Annotations

// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace PartisanNET.App.Wpf.ViewModels;

public class GreetingViewModel : BindableBase, IDisposable
{
    private readonly IDialogServiceAdapter _dialogService;
    private ICommand? _login;
    private readonly IDisposable _idSubscription;

    public GreetingViewModel(
        IDialogServiceAdapter dialogService, 
        IIdentityService identityService,
        IRegionManager regionManager)
    {
        _dialogService = dialogService;

        _idSubscription = identityService.StatusShell.Subscribe(x =>
        {
            if (x.Status is not IdStatus.SignIn) return;
            
            var mainNavigation = regionManager.Regions[Regions.MainRegion].NavigationService;
            mainNavigation.RequestNavigate(Regions.WarriorRegion);
        });
    }

    public ICommand Login => _login ??= new DelegateCommand(() =>
    {
        _dialogService.ShowDialog(Regions.LoginRegion, null);
        
        // TODO: close login dialog after sign in
    });

    public void Dispose()
    {
        _idSubscription.Dispose();
    }
}