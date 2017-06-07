namespace MathExpressionSolver
{
    public class Multiplication : IMathOperation
    {
        public char OparationChar { get; }

        public Multiplication()
        {
            OparationChar = '*';
        }

        public double RunOperation(double leftOp, double rightOp)
        {
            return leftOp * rightOp;
        }
    }
}
