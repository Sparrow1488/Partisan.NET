using System;
using Microsoft.Extensions.DependencyInjection;
using PartisanNET.App.Wpf.Services;
using Prism.Mvvm;

#region Annotations

// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace PartisanNET.App.Wpf.ViewModels;

public class MainViewModel : BindableBase
{
    private readonly GreetingService _greetingService;

    public MainViewModel(IServiceProvider services)
    {
        _greetingService = services.GetRequiredService<GreetingService>();
    }

    public string Text => _greetingService.GetMessage();
}