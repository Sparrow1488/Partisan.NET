using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace PartisanNET.Core.Wpf.Navigation;

public class NavigationService<TViewModel>
{
    private readonly NavigationMaps _maps;
    private readonly IServiceProvider _services;
    private readonly ISubject<object> _currentViewShell = new Subject<object>();

    public NavigationService(NavigationMaps maps, NavigationStore store, IServiceProvider services)
    {
        _maps = maps;
        _services = services;
        _currentViewShell.Subscribe(view => CurrentView = view);
        
        store.StoreNavigation(this);
    }

    public object? CurrentView { get; set; }
    public IObservable<object?> CurrentViewShell => _currentViewShell.AsObservable();
    
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
        var viewModelType = _maps.Maps[viewType];

        var scope = _services.CreateScope().ServiceProvider;

        var view = (ContentControl) ActivatorUtilities.CreateInstance(scope, viewType);
        var viewModel = ActivatorUtilities.CreateInstance(scope, viewModelType);

        view.DataContext = viewModel;

        return (view, viewModel);
    }
}