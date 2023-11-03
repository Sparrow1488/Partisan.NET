using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PartisanNET.Modules.Dialogs.Constants;
using PartisanNET.Modules.Dialogs.Services;
using PartisanNET.Modules.Dialogs.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PartisanNET.Modules.Dialogs.ViewModels;

public class DialogContainerViewModel : BindableBase
{
    private readonly IDialogCoordinator _coordinator;
    private readonly ShellWindowResolver _shellResolver;
    private DelegateCommand? _closeCommand;

    public DialogContainerViewModel(
        IDialogCoordinator coordinator,
        ShellWindowResolver shellResolver)
    {
        _coordinator = coordinator;
        _shellResolver = shellResolver;
    }

    public ICommand CloseCommand => _closeCommand ??= new DelegateCommand(async () =>
    {
        var shell = _shellResolver.Window!;

        var dialog = shell.FindChild<DialogContainerView>();
        
        await _coordinator.HideMetroDialogAsync(
            shell.DataContext,
            dialog
        );
    });
    
    public void NavigateTo(string region, NavigationParameters? parameter, IRegionManager scopeManager)
    {
        var navigation = scopeManager.Regions[DialogRegions.DialogContainerRegion].NavigationService;
        navigation.RequestNavigate(region, parameter);
    }
}