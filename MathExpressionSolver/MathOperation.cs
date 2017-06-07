namespace MathExpressionSolver
{
    public class MathOperation : MathOperationResult
    {
        public double RightOperand { get; }

        public double LeftOperand { get; }

        public IMathOperation Operation { get; }

        public override double Result => Operation.RunOperation(LeftOperand, RightOperand);

        public MathOperation(MathOperationResult leftOp, MathOperationResult rightOp, IMathOperation mathOp) : base(0)
        {
            LeftOperand = leftOp.Result;
            RightOperand = rightOp.Result;
            Operation = mathOp;
        }
    }
}
