using System;
using System.Windows;
using System.Windows.Media;
using ControlzEx.Theming;
using MahApps.Metro.Controls;
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
    private readonly Brush _windowOverlayBrush = new SolidColorBrush(Colors.Black);

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
            FixWindowOverlayBrushInDarkMode(_shellResolver.Window).DataContext, 
            view
        );
        
        viewModel.NavigateTo(region, parameters, view.RegionManagerScope);
    }
    
    private MetroWindow FixWindowOverlayBrushInDarkMode(Window window)
    {
        if (window is not MetroWindow metroWindow)
            throw new ArgumentException("Passed window type should be 'MetroWindow'");

        var currentTheme = ThemeManager.Current.DetectTheme();
        if (currentTheme != null && currentTheme.Name.Contains("Dark"))
        {
            metroWindow.OverlayBrush = _windowOverlayBrush.Clone();
        }

        return metroWindow;
    }
}