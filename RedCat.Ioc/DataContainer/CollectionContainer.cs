using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace RedCat.Ioc.DataContainer
{
    public class CollectionContainer<T> : BaseContainer, IContainer
    {
        private ObservableCollection<T> items;

        public ObservableCollection<T> Items
        {
            get
            {
                return items;
            }
            set
            {
                ChangeProperty<ObservableCollection<T>>(ref items, value);
            }
        }

        public event EventHandler<SelectEventArgs<T>> OnItemSelected;
        private T ClickItem = default(T);

        public CollectionContainer()
        {

        }

        public CollectionContainer(IEnumerable<T> items)
        {
            Items = new ObservableCollection<T>(items);
        }

        public CollectionContainer(ObservableCollection<T> items)
        {
            Items = items;
        }

        public void DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            if (OnItemSelected != null)
            {
                ClickItem = ItemFromTapped(sender);
                OnItemSelected(this, new SelectEventArgs<T>(ClickItem, EventArgsType.DoubleTapped));
            }
        }

        public void Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (OnItemSelected != null)
            {
                ClickItem = ItemFromTapped(sender);
                OnItemSelected(this, new SelectEventArgs<T>(ClickItem, EventArgsType.Tapped));
            }
        }

        public void ItemClick(object sender, ItemClickEventArgs e)
        {
            if (OnItemSelected != null)
            {
                ClickItem = ItemFromClick(e);
                OnItemSelected(this, new SelectEventArgs<T>(ClickItem, EventArgsType.ItemClick));
            }
        }

        protected T ItemFromTapped(object sender)
        {
            return sender as ListViewBase != null ? ItemFromObject((sender as ListViewBase).SelectedItem) : default(T);
        }

        protected T ItemFromClick(ItemClickEventArgs e)
        {
            return ItemFromObject(e.ClickedItem);
        }

        private T ItemFromObject(object obj)
        {
            try
            {
                return obj != null ? (T)obj : default(T);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
