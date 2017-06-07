namespace MathExpressionSolver
{
    public class Subtraction : IMathOperation
    {
        public char OparationChar { get; }

        public Subtraction()
        {
            OparationChar = '-';
        }

        public double RunOperation(double leftOp, double rightOp)
        {
            return leftOp - rightOp;
        }
    }
}
