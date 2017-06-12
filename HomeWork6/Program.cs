using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Рассчитать факториал разными способами
            ExecuteAndShowTime(() =>
                Console.WriteLine(Factorials.FactMul(10)));
            ExecuteAndShowTime(() =>
                Console.WriteLine(Factorials.FactMul2(10)));

            // Перевернуть слова разными способами
            ExecuteAndShowTime(() =>
                Console.WriteLine(StringWordsReverser.ReverseWords2("one_two,_.three!.,_four____five!!!")));
            ExecuteAndShowTime(() =>
                Console.WriteLine(StringWordsReverser.ReverseWords("one_two,_.three!.,_four____five!!!")));

            // Сложить два больших целых неотрицательных числа
            Console.Write("Введите целое неотрицательное слагаемое 1: ");
            var num1 = Console.ReadLine();
            Console.Write("Введите целое неотрицательное слагаемое 2: ");
            var num2 = Console.ReadLine();
            try
            {
                Console.WriteLine($"{num1} + {num2} = {BigIntegersSum.Sum(num1, num2)}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"При решении выражения возникло исключение: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникло исключение: {e.Message}");
            }
        }

        /// <summary>
        /// Выполнить указанный метод и показать время его выполнения
        /// </summary>
        /// <param name="method"> Метод, время выполнения которого рассчитывается </param>
        private static void ExecuteAndShowTime(Action method)
        {
            var tStart = DateTime.Now;
            method();
            Console.WriteLine($"Время выполнения: {DateTime.Now - tStart}\n");
        }
    }
}
