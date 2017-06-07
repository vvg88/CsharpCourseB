using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathExpressionSolver
{
    class MathExpressionParser
    {
        private string expression;
        private char[] operationsSymbols;
        private IEnumerable<IMathOperation> availableOperations;

        public MathExpressionParser(string expr, IEnumerable<IMathOperation> availableOperations)
        {
            expression = expr;
            this.availableOperations = availableOperations;
            operationsSymbols = availableOperations.Select(mathOp => mathOp.OparationChar).ToArray();
        }

        public IList<object> ParseExpression()
        {
            var adoptedExpression = new StringBuilder(expression).Replace(" ", string.Empty)     // Удалить пробелы, заменить точки на запятые
                                                                 .Replace(".", ",").ToString();
            try
            {
                CheckExpression(adoptedExpression);
                return ParseExpression(adoptedExpression);
            }
            catch (ParseExpressionException)
            {
                throw;
            }
        }

        private void CheckExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ParseExpressionException("Выражение пустое!");

            if (expression.Count(symb => symb == '(') != expression.Count(symb => symb == ')'))     // Проверить число скобок в выражении
                throw new ParseExpressionException("Число открывающих скобок не равно числу закрывающих скобок!");

            foreach (var symb in expression)        // Проверить символы
            {
                if (!char.IsDigit(symb)
                    && symb != 'e'
                    && symb != ','
                    && symb != '('
                    && symb != ')'
                    && !operationsSymbols.Contains(symb))
                    throw new ParseExpressionException($"Парсинг символа '{symb}' не поддерживается!");
            }
        }

        private List<object> ParseExpression(string expression)
        {
            List<object> expressionItemsList = new List<object>();

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
                            || (expression[j] == ','))
                        {
                            numBuilder.Append(expression[j]);
                            continue;
                        }
                        break;
                    }
                    var number = 0.0;
                    var correctNumStr = numBuilder.ToString();
                    if (!double.TryParse(correctNumStr.ToString(), out number))
                        throw new ParseExpressionException($"Ошибка при парсинге числа {numBuilder}");
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
    }
}
