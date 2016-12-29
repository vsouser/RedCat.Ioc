using Windows.UI.Xaml.Controls;

namespace RedCat.Ioc.DataContainer.HamburgerMenu
{
    public interface IHamburgerMenuAdapter
    {
        Frame RootFrame { get; }
        HamburgerMenuContainer CreateMenu();
    }
}
