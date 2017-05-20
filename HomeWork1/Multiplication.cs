﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Multiplication : IMathOperation
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
