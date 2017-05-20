using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    public interface IMathOperation
    {
        char OparationChar { get; }

        double RunOperation(double leftOp, double rightOp);
    }
}
