using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public class ItemMovingEventArgs<T> : ItemMovedEventArgs<T>
    {
        public bool Cancel { get; set; }

        public ItemMovingEventArgs(T item) : base(item) { }
    }
}
