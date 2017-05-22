using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        private static IMathOperation[] availableOperations;

        static void Main(string[] args)
        {
            availableOperations = new IMathOperation[]
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
                    //var modifiedString = inputedString.ReplaceIfContains("e-", "e_");

                    //var digitsStr = modifiedString.Split(availableOpsSymbs, StringSplitOptions.RemoveEmptyEntries);
                    //var operationSymbs = modifiedString.Where(opSymb => availableOpsSymbs.Contains(opSymb)).ToArray();

                    //var digits = digitsStr.Select(digit =>
                    //{
                    //    digit = digit.ReplaceIfContains("e_", "e-");
                    //    double res;
                    //    if (digit.Contains('.'))
                    //        res = double.Parse(digit, NumberStyles.Any, CultureInfo.InvariantCulture);
                    //    else
                    //        res = double.Parse(digit, NumberStyles.Any, CultureInfo.CurrentCulture);
                    //    return new MathOperationResult(res);
                    //}).ToArray();

                    //List<object> expressionItems = new List<object>(digits.Length * 2 + 1);
                    //for (int i = 0; i < digits.Length; i++)
                    //{
                    //    expressionItems.Add(digits[i]);
                    //    if (i < digits.Length - 1)
                    //    {
                    //        expressionItems.Add(availableOperations.FirstOrDefault(operation => operation.OparationChar == operationSymbs[i]));
                    //    }
                    //}
                    //var result = SolveExpression(expressionItems);
                    if (!double.IsNaN(result))
                        Console.WriteLine(inputedString + $" = {result}");
                    else
                        Console.WriteLine("В расчете возникла ошибка!");
                }
                else
                {
                    Console.WriteLine("Введено неверное выражение!");
                }
                Console.WriteLine("\nПродолжить: Enter\nВыйти: 'q'");
            }
            while (Console.ReadLine() != "q");
        }

        private static bool CheckExpression(string checkedStr, char[] opSymbs)
        {
            if (checkedStr.Count(symb => symb == '(') != checkedStr.Count(symb => symb == ')'))
                return false;

            foreach (var symb in checkedStr)
            {
                if (!char.IsDigit(symb)
                    && symb != 'e'
                    && symb != ' '
                    && symb != '.'
                    && symb != ','
                    && !opSymbs.Contains(symb))
                    return false;
            }
            return true;
        }

        private static double SolveExpression(IList<object> expression)
        {
            if (expression.Count == 1)
            {
                return expression[0] is MathOperationResult ? (expression[0] as MathOperationResult).Result : (double)expression[0];
            }

            IMathOperation operation;
            if (expression.Any(opertion => opertion is Multiplication || opertion is Division))
            {
                operation = expression.FirstOrDefault(item => item is Multiplication || item is Division) as IMathOperation;
            }
            else
            {
                operation = expression.FirstOrDefault(item => item is IMathOperation) as IMathOperation;
            }

            if (SolveOperation(expression, operation))
            {
                return SolveExpression(expression);
            }
            return double.NaN;
        }

        private static bool SolveOperation(IList<object> expression, IMathOperation operation)
        {
            var opIndx = expression.IndexOf(operation);
            var leftOp = expression[opIndx - 1] as MathOperationResult;
            var rightOp = expression[opIndx + 1] as MathOperationResult;
            MathOperationResult newMathOperation;
            if (operation != null && leftOp != null && rightOp != null)
            {
                newMathOperation = new MathOperation(leftOp, rightOp, operation);
                expression[opIndx - 1] = newMathOperation;
                expression.Remove(operation);
                expression.Remove(rightOp);
                return true;
            }
            return false;
        }

        private static double SolveExpression(string expression)
        {
            var availableOpsSymbs = availableOperations.Select(mathOp => mathOp.OparationChar).ToArray();

            var modifiedString = expression.ReplaceIfContains("e-", "e_");
            var digitsStr = modifiedString.Split(availableOpsSymbs, StringSplitOptions.RemoveEmptyEntries);
            var operationSymbs = modifiedString.Where(opSymb => availableOpsSymbs.Contains(opSymb)).ToArray();

            var digits = digitsStr.Select(digit =>
            {
                digit = digit.ReplaceIfContains("e_", "e-");
                double res;
                if (digit.Contains('.'))
                    res = double.Parse(digit, NumberStyles.Any, CultureInfo.InvariantCulture);
                else
                    res = double.Parse(digit, NumberStyles.Any, CultureInfo.CurrentCulture);
                return new MathOperationResult(res);
            }).ToArray();

            List<object> expressionItems = new List<object>(digits.Length * 2 + 1);
            for (int i = 0; i < digits.Length; i++)
            {
                expressionItems.Add(digits[i]);
                if (i < digits.Length - 1)
                {
                    expressionItems.Add(availableOperations.FirstOrDefault(operation => operation.OparationChar == operationSymbs[i]));
                }
            }
            var result = SolveExpression(expressionItems);
            return result;
        }

        private static IList<object> ParseExpression(string expression)
        {
            List<object> expItemsList = new List<object>();
            // Убрать лишние пробелы
            var expressionBuilder = new StringBuilder(expression);
            for (int i = 0; i < expressionBuilder.Length; i++)
            {
                if (expressionBuilder[i] == ' ')
                    expressionBuilder.Remove(i, 1);
            }
            // Откорректировать е-
            expression = expression.ReplaceIfContains("e-", "e_");

            for (int i = 0; i < expressionBuilder.Length; i++)
            {
                if (char.IsDigit(expressionBuilder[i]))
                {
                    var numBuilder = new StringBuilder(expressionBuilder[i++]);
                    while (char.IsDigit(expressionBuilder[i])
                            || (expressionBuilder[i] == 'e')
                            || (expressionBuilder[i] == '_')
                            || (expressionBuilder[i] == '.')
                            || (expressionBuilder[i] == ','))
                    {
                        numBuilder.Append(expressionBuilder[i++]);
                    }
                    var number = 0.0;
                    var correctNumStr = numBuilder.ToString().ReplaceIfContains("e_", "e-");
                    double.TryParse(correctNumStr, out number);
                    expItemsList.Add(number);
                }
                if ()
            }

            throw new NotImplementedException();
        }

        private static double SolveExpWithBrackets(StringBuilder expression)
        {
            var newExpression = new StringBuilder();
            var openBracket = new { Indx = 0, IsFound = false };
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openBracket = new { Indx = i, IsFound = true };
                }
                if (expression[i] == ')' && openBracket.IsFound)
                {
                    var stringInBrackets = expression.ToString().Substring(openBracket.Indx + 1, i - openBracket.Indx - 1);
                    newExpression = new StringBuilder()
                }
            }

            throw new NotImplementedException();
        }
    }
}
