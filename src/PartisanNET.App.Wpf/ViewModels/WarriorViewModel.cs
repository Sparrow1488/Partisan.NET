using System;
using PartisanNET.App.Wpf.Views;
using PartisanNET.Core.Wpf.Navigation;
using Prism.Mvvm;

namespace PartisanNET.App.Wpf.ViewModels;

public class WarriorViewModel : BindableBase
{
    private object? _squadView;

    public WarriorViewModel(NavigationService navigation)
    {
        navigation = navigation.CreateScoped();
        navigation.CurrentViewShell.Subscribe(view => SquadView = view);
        
        navigation.Navigate<SquadView>();
    }

    public object? SquadView
    {
        get => _squadView;
        set => SetProperty(ref _squadView, value);
    }
}