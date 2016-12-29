namespace RedCat.Ioc.DataContainer
{
    public class ItemContainer<T> : BaseContainer, IContainer
    {
        private T item;

        public T Item
        {
            get
            {
                return item;
            }
            set
            {
                ChangeProperty<T>(ref item, value);
            }
        }


        public ItemContainer(T item)
        {
            Item = item;
        }
    }
}
