using System;
using System.Collections.Generic;

namespace PartisanNET.Core.Wpf.Navigation;

public class NavigationStore
{
    private readonly Dictionary<Type, object> _navigations = new();

    public void StoreNavigation<TViewModel>(NavigationService<TViewModel> navigation)
    {
        _navigations[typeof(TViewModel)] = navigation;
    }

    public NavigationService<TViewModel> GetRequiredNavigation<TViewModel>()
    {
        return GetNavigation<TViewModel>() ?? throw new NullReferenceException();
    }
    
    public NavigationService<TViewModel>? GetNavigation<TViewModel>()
    {
        return _navigations.TryGetValue(typeof(TViewModel), out var navigation)
            ? (NavigationService<TViewModel>) navigation
            : default;
    }
}