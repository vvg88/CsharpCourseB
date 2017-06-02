using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkUtils
{
    public class MathOperationResult
    {
        private double result;
        public virtual double Result
        {
            get { return result; }
        }

        public MathOperationResult(double result)
        {
            this.result = result;
        }
    }
}
