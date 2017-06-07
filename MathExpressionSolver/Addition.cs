namespace MathExpressionSolver
{
    public class Addition : IMathOperation
    {
        public char OparationChar { get; }

        public Addition()
        {
            OparationChar = '+';
        }

        public double RunOperation(double leftOp, double rightOp)
        {
            return leftOp + rightOp;
        }
    }
}
