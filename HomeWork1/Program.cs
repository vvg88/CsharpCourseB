using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            IMathOperation[] availableOperations = new IMathOperation[]
            {
                new Addition(), new Subtraction(), new Multiplication(), new Division()
            };
            var availableOpsSymbs = availableOperations.Select(mathOp => mathOp.OparationChar).ToArray();

            do
            {
                Console.WriteLine("Введите выражение:");
                var inputedString = Console.ReadLine();
                if (CheckExpression(inputedString, availableOpsSymbs))
                {
                    var digitsStr = inputedString.Split(availableOpsSymbs, StringSplitOptions.RemoveEmptyEntries);
                    var operationSymbs = inputedString.Where(opSymb => availableOpsSymbs.Contains(opSymb));
                    Console.WriteLine("Введено правильное выражение!");
                }
                else
                {
                    Console.WriteLine("Введено неверное выражение!");
                }
                Console.WriteLine("Для выхода введите 'q'");
            }
            while (Console.ReadLine() != "q");
        }

        private static bool CheckExpression(string checkedStr, char[] opSymbs)
        {
            foreach (var symb in checkedStr)
            {
                if (!char.IsDigit(symb)
                    && symb != 'e'
                    && symb != ' '
                    && !opSymbs.Contains(symb))
                    return false;
            }
            return true;
        }
    }
}
