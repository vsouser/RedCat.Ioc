using RedCat.Ioc.DataContainer.HamburgerMenu;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RedCat.Ioc.ViewContainer
{
    public abstract class BaseViewModelContainer : BaseContainer
    {
        private IHamburgerMenuAdapter menuAdapter;

        protected Page ViewPage;

        public double WW
        {
            get
            {
                return Window.Current.Bounds.Width;
            }
        }

        public double WH
        {
            get
            {
                return Window.Current.Bounds.Height;
            }
        }

        private HamburgerMenuContainer hamburger;

        public HamburgerMenuContainer Menu
        {
            get
            {
                return hamburger;
            }
            set
            {
                ChangeProperty(ref hamburger, value);
            }
        }

        public void SetState(string name)
        {
            if(ViewPage != null)
                VisualStateManager.GoToState(ViewPage, name, false);
        }

        public void SetState(string name, bool userTransitions)
        {
            if(ViewPage != null)
                VisualStateManager.GoToState(ViewPage, name, userTransitions);
        }

        public BaseViewModelContainer(IHamburgerMenuAdapter menuAdapter)
        {
            Menu = menuAdapter.CreateMenu();
        }

        public BaseViewModelContainer(IHamburgerMenuAdapter menuAdapter, Page viewPage)
        {
            Menu = menuAdapter.CreateMenu();
            ViewPage = viewPage;
        }

        public BaseViewModelContainer()
        {

        }
    }
}
