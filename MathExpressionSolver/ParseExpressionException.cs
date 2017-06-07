using System;

namespace MathExpressionSolver
{
    public class ParseExpressionException : Exception
    {
        public ParseExpressionException(string message) : base (message)
        { }
    }
}
