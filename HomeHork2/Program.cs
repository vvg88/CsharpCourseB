using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector<int> a = new Vector<int>(1, 2);
            Console.WriteLine($"Вектор а: {a}");
            Vector<int> b = new Vector<int>(1, 2);
            Console.WriteLine($"Вектор b: {b}");
            Console.WriteLine($"Векторы а и b {(a == b ? "равны" : "не равны")}");
            var c = a + b;
            Console.WriteLine($"Вектор а + b: {a + b}");


        }
    }
}
