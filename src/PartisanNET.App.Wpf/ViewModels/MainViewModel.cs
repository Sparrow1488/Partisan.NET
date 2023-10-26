using System;
using PartisanNET.App.Wpf.Views;
using PartisanNET.Core.Wpf.Navigation;
using Prism.Mvvm;

#region Annotations

// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace PartisanNET.App.Wpf.ViewModels;

public class MainViewModel : BindableBase
{
    private object? _currentView;

    public MainViewModel(NavigationService<MainViewModel> navigation)
    {
        navigation.CurrentViewShell.Subscribe(view => CurrentView = view);
        
        navigation.Navigate<GreetingView>();
    }

    public object? CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }
}