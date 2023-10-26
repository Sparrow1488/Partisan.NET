using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace PartisanNET.Core.Wpf.Navigation;

public class NavigationService
{
    private readonly Dictionary<Type, Type> _maps;
    private readonly IServiceProvider _services;
    private readonly ISubject<object> _currentViewShell = new Subject<object>();

    public NavigationService(Dictionary<Type, Type> maps, IServiceProvider services)
    {
        _maps = maps;
        _services = services;
        _currentViewShell.Subscribe(view => CurrentView = view);
    }

    public object? CurrentView { get; set; }
    public IObservable<object?> CurrentViewShell => _currentViewShell.AsObservable();

    public NavigationService CreateScoped()
    {
        var scope = _services.CreateScope().ServiceProvider;
        return ActivatorUtilities.CreateInstance<NavigationService>(scope, _maps);
    }
    
    public void Navigate<TView>() => NavigateCore<TView>();
    private (object View, object ViewModel) NavigateCore<TView>() => NavigateCore(typeof(TView));
    
    private (object View, object ViewModel) NavigateCore(Type viewType)
    {
        var pairs = CreateViewPairs(viewType);
        _currentViewShell.OnNext(pairs.View);

        return pairs;
    }

    private (object View, object ViewModel) CreateViewPairs(Type viewType)
    {
        var viewModelType = _maps[viewType];

        var view = (ContentControl) ActivatorUtilities.CreateInstance(_services, viewType);
        var viewModel = ActivatorUtilities.CreateInstance(_services, viewModelType);

        view.DataContext = viewModel;

        return (view, viewModel);
    }
}