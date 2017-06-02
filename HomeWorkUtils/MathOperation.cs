using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkUtils
{
    public class MathOperation : MathOperationResult
    {
        public double RightOperand { get; }

        public double LeftOperand { get; }

        public IMathOperation Operation { get; }

        public override double Result
        {
            get { return Operation.RunOperation(LeftOperand, RightOperand); }
        }

        public MathOperation(MathOperationResult leftOp, MathOperationResult rightOp, IMathOperation mathOp) : base(0)
        {
            LeftOperand = leftOp.Result;
            RightOperand = rightOp.Result;
            Operation = mathOp;
        }
    }
}
