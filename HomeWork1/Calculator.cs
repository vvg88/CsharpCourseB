using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Calculator
    {
        private static string baseExpression =
        @"using System;
        namespace MyNamespace
        {
            class Prog
            {
                public static double Solve()
                {
                    return" + expression + @"
                }
            }
        }";

        private static string expression;

        public Calculator(string expr)
        {
            expression = expr;
        }

        public double Solve()
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            parameters.GenerateInMemory = true;
            var results = provider.CompileAssemblyFromSource(parameters, baseExpression);
            return 0;
        }
    }
}
