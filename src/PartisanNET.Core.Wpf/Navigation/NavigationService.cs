using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace PartisanNET.Core.Wpf.Navigation;

public class NavigationService<TViewModelCtx>
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
    
    public void NavigateRequest<TViewModel>() => NavigateCore<TViewModel>(true);

    public void Navigate<TViewModel>(Action<object> viewCallback)
    {
        var (view, _) = NavigateCore<TViewModel>(false);
        viewCallback.Invoke(view);
    }
    
    private (object View, object ViewModel) NavigateCore<TViewModel>(bool notifyShell) 
        => NavigateCore(typeof(TViewModel), notifyShell);
    
    private (object View, object ViewModel) NavigateCore(Type viewModelType, bool notifyShell)
    {
        var pairs = CreateViewPairs(viewModelType);
        
        if (notifyShell)
            _requestsShell.OnNext(pairs.View);

        return pairs;
    }

    private (object View, object ViewModel) CreateViewPairs(Type viewModelType)
    {
        if (!_maps.Maps.TryGetValue(viewModelType, out var viewType))
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