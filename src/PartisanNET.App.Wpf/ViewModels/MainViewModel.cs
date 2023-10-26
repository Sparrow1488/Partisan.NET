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
    private object? _topView;

    public MainViewModel(NavigationService<MainViewModel> navigation)
    {
        navigation.Requests.Subscribe(view => CurrentView = view);
        
        navigation.Navigate<GreetingView>(view => CurrentView = view);
        navigation.Navigate<GlobalTopView>(view => TopView = view);
    }

    public object? CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }
    
    public object? TopView
    {
        get => _topView;
        set => SetProperty(ref _topView, value);
    }
}