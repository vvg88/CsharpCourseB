namespace HomeWork3
{
    public class ItemMovingEventArgs<T> : ItemMovedEventArgs<T>
    {
        public bool Cancel { get; set; }

        public ItemMovingEventArgs(T item) : base(item) { }
    }
}
