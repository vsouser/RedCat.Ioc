using System;

namespace RedCat.Ioc.DataContainer
{
    public class SelectEventArgs<T> : EventArgs
    {
        public SelectEventArgs(T item, EventArgsType eventType)
        {
            Item = item;
            EventType = eventType;
        }

        public T Item { get; private set; }
        public EventArgsType EventType { get; private set; }
    }
}
