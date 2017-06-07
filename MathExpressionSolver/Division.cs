namespace MathExpressionSolver
{
    public class Division : IMathOperation
    {
        public char OparationChar { get; }

        public Division()
        {
            OparationChar = '/';
        }

        public double RunOperation(double leftOp, double rightOp)
        {
            return leftOp / rightOp;
        }
    }
}
