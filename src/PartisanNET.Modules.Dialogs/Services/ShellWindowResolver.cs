using System.Windows;

namespace PartisanNET.Modules.Dialogs.Services;

public class ShellWindowResolver
{
    public ShellWindowResolver(Window? window)
    {
        Window = window;
    }
    
    public Window? Window { get; }
}