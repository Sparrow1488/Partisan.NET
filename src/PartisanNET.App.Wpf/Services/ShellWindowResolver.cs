using System.Windows;

namespace PartisanNET.App.Wpf.Services;

public class ShellWindowResolver
{
    public Window? Window => Application.Current.MainWindow;
}