using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {

        struct ms
        {
            public int a;
            public int b;
        }

        static void Main(string[] args)
        {
            Vector<int> a = new Vector<int>(1, 2);
            Console.WriteLine($"Вектор а: {a}");
            Vector<int> b = new Vector<int>(1, 2);
            Console.WriteLine($"Вектор b: {b}");
            Console.WriteLine($"Векторы а и b {(a == b ? "равны" : "не равны")}");
            Console.WriteLine($"Вектор а + b: {a + b}\n");

            Console.WriteLine("Сгенерировать массив векторов:");
            var vectGen = new VectorGenerator<int>(5);
            foreach (var vect in vectGen)
                Console.WriteLine(vect);

            Console.WriteLine($"5!: {Factorial(3)}");
        }

        private static double Factorial(int n)
        {
            Stack<double> stack = new Stack<double>();
            stack.Push(1);
            for (int i = 1; i <= n; i++)
                stack.Push(stack.Pop() * i);
            return stack.Pop();
        }
    }
}
