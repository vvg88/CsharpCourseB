﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    class SolveExpressionException : Exception
    {
        public SolveExpressionException(string message) : base (message)
        { }
    }
}
