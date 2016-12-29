using Windows.UI.Xaml.Controls;

namespace RedCat.Ioc.DataContainer.HamburgerMenu
{
    public class HamburgerMenuContainer : CollectionContainer<HamburgerMenuItem>
    {
        Frame rootFrame;

        public HamburgerMenuContainer(Frame rootFrame)
        {
            this.rootFrame = rootFrame;
            this.OnItemSelected += HamburgerMenuContainer_OnItemSelected;
        }

        private void HamburgerMenuContainer_OnItemSelected(object sender, SelectEventArgs<HamburgerMenuItem> e)
        {
            if (rootFrame != null)
            {
                rootFrame.Navigate(e.Item.Page);
            }
        }

        private bool isPaneOpen = false;

        public bool IsPaneOpen
        {
            get
            {
                return isPaneOpen;
            }
            set
            {
                ChangeProperty(ref isPaneOpen, value);
            }
        }

        public void ShowPane()
        {
            IsPaneOpen = IsPaneOpen == false ? true : false;
        }
    }
}
