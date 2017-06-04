using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExpressionSolver;

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

        private static bool CheckExpression(string checkedStr, char[] opSymbs)
        {
            if (checkedStr.Count(symb => symb == '(') != checkedStr.Count(symb => symb == ')'))     // Проверить число скобок в выражении
                return false;

            foreach (var symb in checkedStr)        // Проверить символы
            {
                if (!char.IsDigit(symb)
                    && symb != 'e'
                    && symb != ','
                    && symb != '('
                    && symb != ')'
                    && !opSymbs.Contains(symb))
                    return false;
            }
            return true;
        }

        private static double SolveExpressionNoBrackets(IList<object> expression)
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
                return SolveExpressionNoBrackets(expression);
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
        
        private static List<object> ParseExpression(string expression)
        {
            List<object> expressionItemsList = new List<object>();
            expression = expression.ReplaceIfContains("e-", "e_");

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    var numBuilder = new StringBuilder();
                    for (int j = i; j < expression.Length; j++)
                    {
                        if (char.IsDigit(expression[j])
                            || (expression[j] == 'e')
                            || (expression[j] == '_')
                            || (expression[j] == '.')
                            || (expression[j] == ','))
                        {
                            numBuilder.Append(expression[j]);
                            continue;
                        }
                        break;
                    }
                    var number = 0.0;
                    var correctNumStr = numBuilder.ReplaceIfContains("e_", "e-");
                    double.TryParse(correctNumStr.ToString(),  out number);
                    expressionItemsList.Add(new MathOperationResult(number));
                    i += numBuilder.Length - 1;
                    continue;
                }
                if (expression[i] == '(' || expression[i] == ')')
                {
                    expressionItemsList.Add(expression[i]);
                }
                if (availableOperations.Any(mathOp => mathOp.OparationChar == expression[i]))
                {
                    expressionItemsList.Add(availableOperations.FirstOrDefault(mathOp => mathOp.OparationChar == expression[i]));
                }
            }
            return expressionItemsList;
        }

        private static double SolveExpWithBrackets(List<object> expression)
        {
            var openBracket = new { Indx = 0, IsFound = false };
            while (expression.Contains('(') || expression.Contains(')'))
            {
                for (int i = 0; i < expression.Count; i++)
                {
                    if (expression[i] is char && (char)expression[i] == '(')
                    {
                        openBracket = new { Indx = i, IsFound = true };
                    }
                    if (expression[i] is char && (char)expression[i] == ')' && openBracket.IsFound)
                    {
                        var expressionInBrackets = expression.GetRange(openBracket.Indx + 1, i - openBracket.Indx - 1);
                        var expressionResult = SolveExpressionNoBrackets(expressionInBrackets);
                        expression[openBracket.Indx] = new MathOperationResult(expressionResult);
                        expression.RemoveRange(openBracket.Indx + 1, i - openBracket.Indx);
                        openBracket = new { Indx = 0, IsFound = false };
                    }
                }
            }
            return SolveExpressionNoBrackets(expression);
        }
    }
}
