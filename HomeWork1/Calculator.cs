using Microsoft.CSharp;
using System.CodeDom.Compiler;

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
