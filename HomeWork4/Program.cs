using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите выражение:");
                var expressionSolver = new MathExpressionSolver(Console.ReadLine());
                try
                {
                    Console.WriteLine($"Результат выражения: {expressionSolver.SolveExpression()}");
                }
                catch(ParseExpressionException exc)
                {
                    Console.WriteLine($"При парсинге выражения возникло исключение: {exc.Message}");
                    continue;
                }
                catch(SolveExpressionException exc)
                {
                    Console.WriteLine($"При решении выражения возникло исключение: {exc.Message}");
                    continue;
                }

                Console.WriteLine("\nПродолжить: Enter\nВыйти: 'q'");
            }
            while (Console.ReadLine() != "q");

            var someDate = new DateTime(1888, 6, 2);
            Console.WriteLine($"С даты {someDate} прошло {someDate.Age()} лет.\n");

            Console.WriteLine("Какие-то даты:");
            foreach (var date in GetSomeDates().DatesToStrings())
                Console.WriteLine(date);
        }

        private static IEnumerable<DateTime> GetSomeDates()
        {
            yield return new DateTime(2000, 12, 31);
            yield return new DateTime(1771, 1, 31);
            yield return new DateTime(1941, 6, 22);
            yield return new DateTime(1945, 5, 9);
            yield return new DateTime(1380, 9, 8);
        }
    }
}
