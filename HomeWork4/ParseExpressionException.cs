using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    class ParseExpressionException : Exception
    {
        public ParseExpressionException(string message) : base (message)
        { }
    }
}
