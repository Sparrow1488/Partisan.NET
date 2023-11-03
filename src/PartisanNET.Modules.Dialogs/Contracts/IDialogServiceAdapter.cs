using Prism.Regions;

namespace PartisanNET.Modules.Dialogs.Contracts;

public interface IDialogServiceAdapter
{
    void ShowDialog(string region, NavigationParameters? parameters);
}