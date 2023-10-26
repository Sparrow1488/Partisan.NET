using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PartisanNET.App.Wpf.ViewModels;

namespace PartisanNET.App.Wpf.Views;

public partial class MainWindow : Window
{
    public MainWindow(IServiceProvider services)
    {
        InitializeComponent();
        
        DataContext = services.GetRequiredService<MainViewModel>();
    }
}