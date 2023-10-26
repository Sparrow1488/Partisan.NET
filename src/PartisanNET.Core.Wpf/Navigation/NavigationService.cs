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
    private readonly ISubject<object> _requestsShell = new Subject<object>();

    public NavigationService(NavigationMaps maps, NavigationStore store, IServiceProvider services)
    {
        _maps = maps;
        _services = services;
        _requestsShell.Subscribe(view => CurrentView = view);
        
        store.StoreNavigation(this);
    }

    public object? CurrentView { get; set; }
    public IObservable<object?> Requests => _requestsShell.AsObservable();
    
    public void NavigateRequest<TView>() => NavigateCore<TView>(true);

    public void Navigate<TView>(Action<object> viewCallback)
    {
        var (view, _) = NavigateCore<TView>(false);
        viewCallback.Invoke(view);
    }
    
    private (object View, object ViewModel) NavigateCore<TView>(bool notifyShell) 
        => NavigateCore(typeof(TView), notifyShell);
    
    private (object View, object ViewModel) NavigateCore(Type viewType, bool notifyShell)
    {
        var pairs = CreateViewPairs(viewType);
        
        if (notifyShell)
            _requestsShell.OnNext(pairs.View);

        return pairs;
    }

    private (object View, object ViewModel) CreateViewPairs(Type viewType)
    {
        if (!_maps.Maps.TryGetValue(viewType, out var viewModelType))
        {
            throw new InvalidOperationException($"Данный тип {viewType.Name} не зарегистрирован для навигации");
        }

        var scope = _services.CreateScope().ServiceProvider;

        var view = (ContentControl) ActivatorUtilities.CreateInstance(scope, viewType);
        var viewModel = ActivatorUtilities.CreateInstance(scope, viewModelType);

        view.DataContext = viewModel;

        return (view, viewModel);
    }
}