using System;
using PartisanNET.App.Wpf.Views;
using PartisanNET.Core.Wpf.Navigation;
using Prism.Mvvm;

namespace PartisanNET.App.Wpf.ViewModels;

public class WarriorViewModel : BindableBase
{
    private object? _squadView;

    public WarriorViewModel(NavigationService<WarriorViewModel> navigation)
    {
        navigation.Requests.Subscribe(view => SquadView = view);
        navigation.NavigateRequest<SquadView>();
    }

    public object? SquadView
    {
        get => _squadView;
        set => SetProperty(ref _squadView, value);
    }
}