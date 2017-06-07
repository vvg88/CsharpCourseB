using System;

namespace MathExpressionSolver
{
    public class SolveExpressionException : Exception
    {
        public SolveExpressionException(string message) : base (message)
        { }
    }
}
