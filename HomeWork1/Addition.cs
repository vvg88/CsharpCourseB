using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
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
