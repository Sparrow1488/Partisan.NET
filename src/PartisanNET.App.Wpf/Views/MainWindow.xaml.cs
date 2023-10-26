using PartisanNET.App.Wpf.ViewModels;

namespace PartisanNET.App.Wpf.Views;

public partial class MainWindow
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}
