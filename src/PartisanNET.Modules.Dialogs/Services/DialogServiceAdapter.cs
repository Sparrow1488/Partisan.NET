using System;
using MahApps.Metro.Controls.Dialogs;
using PartisanNET.Modules.Dialogs.Contracts;
using PartisanNET.Modules.Dialogs.ViewModels;
using PartisanNET.Modules.Dialogs.Views;
using Prism.Ioc;
using Prism.Regions;

namespace PartisanNET.Modules.Dialogs.Services;

public class DialogServiceAdapter : IDialogServiceAdapter
{
    private readonly IDialogCoordinator _coordinator;
    private readonly ShellWindowResolver _shellResolver;
    private readonly IContainerProvider _container;

    public DialogServiceAdapter(
        IDialogCoordinator coordinator, 
        ShellWindowResolver shellResolver,
        IContainerProvider container)
    {
        _coordinator = coordinator;
        _shellResolver = shellResolver;
        _container = container;
    }
    
    public async void ShowDialog(string region, NavigationParameters? parameters)
    {
        if (_shellResolver.Window is null) 
            throw new InvalidOperationException("Shell Window should be resolve");

        using var containerScope = _container.CreateScope();
        
        var viewModel = containerScope.Resolve<DialogContainerViewModel>();
        var view = containerScope.Resolve<DialogContainerView>();

        view.DataContext = viewModel;
        
        await _coordinator.ShowMetroDialogAsync(
            _shellResolver.Window.DataContext, 
            view
        );
        
        viewModel.NavigateTo(region, parameters, view.RegionManagerScope);
    }
}