using System;
using System.Linq;

namespace HomeWork3
{
    class Program
    {
        static void Main()
        {
            var myList = new MyList<string>(new[] { "Элемент 1", "Элемент 2", "Элемент 3" });
            myList.ItemAdding += (s, e) => Console.WriteLine($"Перед добавлением элемента: {e.Item}");
            myList.ItemAdded += (s, e) => Console.WriteLine($"Элемент {e.Item} добавлен.");

            Console.WriteLine("Элементы коллекции:");
            foreach (var item in myList)
                Console.WriteLine(item);

            var newItem = "Цифра 1";
            myList.Add(newItem);

            myList.ItemAdding += (s, e) => e.Cancel = true;
            myList.Add("Буква А");

            myList.ItemRemoving += (s, e) => Console.WriteLine($"Перед удалением элемента: {e.Item}");
            myList.ItemRemoved += (s, e) => Console.WriteLine($"Элемент {e.Item} удален.");
            myList.Remove(myList.ElementAt(0));

            Console.WriteLine($"Список содержит {myList.Count} элементов.");
            Console.WriteLine($"Список доступен {(myList.IsReadOnly ? "только для чтения" : "для чтения и записи")}.");

            myList.ListClearing += (s, e) => Console.WriteLine("Перед очисткой списка.");
            myList.ListCleared += (s, e) => Console.WriteLine("Список очищен.");
            myList.Clear();
        }
    }
}
