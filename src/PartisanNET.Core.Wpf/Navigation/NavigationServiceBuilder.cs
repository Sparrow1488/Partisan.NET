using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace PartisanNET.Core.Wpf.Navigation;

public class NavigationServiceBuilder
{
    private readonly IServiceProvider _services;
    private readonly Dictionary<Type, Type> _maps = new();

    public NavigationServiceBuilder(IServiceProvider services)
    {
        _services = services;
    }

    public void AddNavigation<TView, TViewModel>()
    {
        _maps.Add(typeof(TView), typeof(TViewModel));
    }

    public NavigationService Build() 
        => ActivatorUtilities.CreateInstance<NavigationService>(_services, _maps);
}