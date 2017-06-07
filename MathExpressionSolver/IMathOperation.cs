namespace MathExpressionSolver
{
    public interface IMathOperation
    {
        char OparationChar { get; }

        double RunOperation(double leftOp, double rightOp);
    }
}
