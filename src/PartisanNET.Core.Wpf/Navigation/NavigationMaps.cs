using System;
using System.Collections.Generic;

namespace PartisanNET.Core.Wpf.Navigation;

public class NavigationMaps
{
    private readonly Dictionary<Type, Type> _maps = new();

    public IReadOnlyDictionary<Type, Type> Maps => _maps.AsReadOnly();

    public void AddNavigation<TView, TViewModel>()
    {
        _maps.Add(typeof(TViewModel), typeof(TView));
    }
}