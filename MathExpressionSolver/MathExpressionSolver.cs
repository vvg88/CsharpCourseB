using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionSolver
{
    public class MathExpressionSolve
    {
        private string expression;
        private IMathOperation[] availableOperations = new IMathOperation[]
        {
            new Addition(), new Subtraction(), new Multiplication(), new Division()
        };

        public MathExpressionSolve(string expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Найти решение выражения
        /// </summary>
        /// <returns> Результат выражения </returns>
        public double SolveExpression()
        {
            var expression = ParseExpression();
            var openBracket = new { Indx = 0, IsFound = false };
            while (expression.Contains('(') || expression.Contains(')'))
            {
                for (int i = 0; i < expression.Count; i++)
                {
                    if (expression[i] is char)
                    {
                        if ((char)expression[i] == '(')
                        {
                            openBracket = new { Indx = i, IsFound = true };
                        }
                        if ((char)expression[i] == ')' && openBracket.IsFound)
                        {
                            var expressionInBrackets = expression.GetRange(openBracket.Indx + 1, i - openBracket.Indx - 1);
                            var expressionResult = SolveExpressionNoBrackets(expressionInBrackets);
                            expression[openBracket.Indx] = new MathOperationResult(expressionResult);
                            expression.RemoveRange(openBracket.Indx + 1, i - openBracket.Indx);
                            openBracket = new { Indx = 0, IsFound = false };
                        }
                    }
                }
            }
            return SolveExpressionNoBrackets(expression);
        }

        private List<object> ParseExpression()
        {
            try
            {
                var parser = new MathExpressionParser(expression, availableOperations);
                return new List<object>(parser.ParseExpression());
            }
            catch(ParseExpressionException)
            {
                throw;
            }
        }

        /// <summary>
        /// Решить выражение без скобок
        /// </summary>
        /// <param name="expression"> Решаемое выражение </param>
        /// <returns> Результат выражения </returns>
        private double SolveExpressionNoBrackets(IList<object> expression)
        {
            if (expression.Count == 1)
            {
                try
                {
                    var exprResult = expression[0] is MathOperationResult ? (expression[0] as MathOperationResult).Result : (double)expression[0];
                    return exprResult;
                }
                catch (Exception exc)
                {
                    throw new SolveExpressionException($"При решении выражения возникло исключение: {exc.Message}");
                }
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

            try
            {
                SolveOperation(expression, operation);
            }
            catch(SolveExpressionException)
            {
                throw;
            }
            return SolveExpressionNoBrackets(expression);
        }

        /// <summary>
        /// Найти результат одной операции
        /// </summary>
        /// <param name="expression"> Полное выражение с этой операцией </param>
        /// <param name="operation"> Операция </param>
        private void SolveOperation(IList<object> expression, IMathOperation operation)
        {
            var opIndx = expression.IndexOf(operation);
            var leftOp = expression[opIndx - 1] as MathOperationResult;
            var rightOp = expression[opIndx + 1] as MathOperationResult;
            MathOperationResult newMathOperation;

            if (operation == null)
                throw new SolveExpressionException($"Опереация не определена!");
            if (leftOp == null)
                throw new SolveExpressionException($"Левый опереанд {expression[opIndx - 1]} не определен!");
            if (rightOp == null)
                throw new SolveExpressionException($"Правый опереанд {expression[opIndx + 1]} не определен!");

            newMathOperation = new MathOperation(leftOp, rightOp, operation);
            expression[opIndx - 1] = newMathOperation;
            expression.Remove(operation);
            expression.Remove(rightOp);
        }
    }
}
