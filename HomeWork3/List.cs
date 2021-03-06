﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork3
{
    public class MyList<T> : ICollection<T>
    {
        private readonly List<T> internalList;

        /// <summary>
        /// Событие добавления нового элемента в список
        /// </summary>
        public event EventHandler<ItemMovingEventArgs<T>> ItemAdding;
        /// <summary>
        /// Событие, возникающее после добавления нового элемента в список
        /// </summary>
        public event EventHandler<ItemMovedEventArgs<T>> ItemAdded;

        /// <summary>
        /// Событие удаления элемента из списка
        /// </summary>
        public event EventHandler<ItemMovingEventArgs<T>> ItemRemoving;
        /// <summary>
        /// Событие, возникающее после удаления элемента из списка
        /// </summary>
        public event EventHandler<ItemMovedEventArgs<T>> ItemRemoved;

        /// <summary>
        /// Событие очистки списка
        /// </summary>
        public event EventHandler<ListClearingEventArgs> ListClearing;
        /// <summary>
        /// Событие после очистки списка
        /// </summary>
        public event EventHandler<EventArgs> ListCleared;

        public MyList(IEnumerable<T> list)
        {
            internalList = new List<T>(list);
        }

        /// <summary>
        /// Число элементов в списке
        /// </summary>
        public int Count => internalList.Count;

        /// <summary>
        /// Признак, что список доступен только для чтения
        /// </summary>
        public bool IsReadOnly => (internalList as ICollection<T>).IsReadOnly;

        /// <summary>
        /// Добавить новый элемент в список
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            var addingEvArg = OnItemAdding(item);
            if (addingEvArg.Cancel)
            {
                Console.WriteLine($"Добавление элемента {addingEvArg.Item} отменено!");
                return;
            }
            internalList.Add(item);
            OnItemAdded(item);
        }

        /// <summary>
        /// Очмстить список
        /// </summary>
        public void Clear()
        {
            var evArg = OnListClearing();
            if (evArg.Cancel)
            {
                Console.WriteLine("Очистка списка отменена!");
                return;
            }
            internalList.Clear();
            OnListCleared();
        }

        /// <summary>
        /// Проверить, содержит ли список указанный элемент
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return internalList.Contains<T>(item);
        }

        /// <summary>
        /// Копировать весь список в указанный массив начиная с указанного индекса
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        /// <summary>
        /// Удалить указанный элемент
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            var rmvEvArg = OnItemRemoving(item);
            if (rmvEvArg.Cancel)
            {
                Console.WriteLine($"Удаление элемента {rmvEvArg.Item} отменено!");
                return false;
            }
            var removeResult = internalList.Remove(item);
            OnItemRemoved(item);
            return removeResult;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected virtual ItemMovingEventArgs<T> OnItemAdding(T item)
        {
            var evArg = new ItemMovingEventArgs<T>(item);
            ItemAdding?.Invoke(this, evArg);
            return evArg;
        }

        protected virtual void OnItemAdded(T item)
        {
            var evArg = new ItemMovedEventArgs<T>(item);
            ItemAdded?.Invoke(this, evArg);
        }

        protected virtual ItemMovingEventArgs<T> OnItemRemoving(T item)
        {
            var evArg = new ItemMovingEventArgs<T>(item);
            ItemRemoving?.Invoke(this, evArg);
            return evArg;
        }

        protected virtual void OnItemRemoved(T item)
        {
            var evArg = new ItemMovedEventArgs<T>(item);
            ItemRemoved?.Invoke(this, evArg);
        }

        protected virtual ListClearingEventArgs OnListClearing()
        {
            var evArg = new ListClearingEventArgs();
            ListClearing?.Invoke(this, evArg);
            return evArg;
        }

        protected virtual void OnListCleared()
        {
            var evArg = EventArgs.Empty;
            ListCleared?.Invoke(this, evArg);
        }
    }
}
