using System;
using MathExpressionSolver;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите выражение:");
                var expressionSolver = new MathExpressionSolve(Console.ReadLine());
                try
                {
                    Console.WriteLine($"Результат выражения: {expressionSolver.SolveExpression()}");
                }
                catch (ParseExpressionException exc)
                {
                    Console.WriteLine($"При парсинге выражения возникло исключение: {exc.Message}");
                    continue;
                }
                catch (SolveExpressionException exc)
                {
                    Console.WriteLine($"При решении выражения возникло исключение: {exc.Message}");
                    continue;
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"Возникло необработанное исключение: {exc.Message}");
                }
                Console.WriteLine("\nПродолжить: Enter\nВыйти: 'q'");
            }
            while (Console.ReadLine() != "q");
        }
    }
}
