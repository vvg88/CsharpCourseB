using System;

namespace HomeWork3
{
    public class ItemMovedEventArgs<T> : EventArgs
    {
        public T Item { get; }

        public ItemMovedEventArgs(T item)
        {
            Item = item;
        }
    }
}
