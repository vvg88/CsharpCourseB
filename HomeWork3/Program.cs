using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList<string>(new string[] { "Элемент 1", "Элемент 2", "Элемент 3" });
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
        }
    }
}
