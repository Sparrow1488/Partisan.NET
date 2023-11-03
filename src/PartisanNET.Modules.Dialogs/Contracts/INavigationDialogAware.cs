using Prism.Regions;

namespace PartisanNET.Modules.Dialogs.Contracts;

public interface INavigationDialogAware : INavigationAware
{
    void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext) { }

    bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext) => true;
}