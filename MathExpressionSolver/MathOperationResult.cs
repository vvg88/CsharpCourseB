namespace MathExpressionSolver
{
    public class MathOperationResult
    {
        public virtual double Result { get; }

        public MathOperationResult(double result)
        {
            Result = result;
        }
    }
}
