using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    static class Factorials
    {
        /// <summary>
        /// Рассчитать произведение факториалов 1! * 2! * 3! * ... * n!
        /// </summary>
        /// <param name="n"></param>
        /// <returns> Произведение факториалов </returns>
        public static double FactMul(uint n)
        {
            var result = 1.0;    // Результат расчета
            var factResult = 1.0;
            for (uint i = 2; i <= n; i++)
            {
                factResult *= i;              // Рассчитать факториал
                result *= factResult;         // Умножить результат на рассчитанный факториал
            }
            return result;
        }

        /// <summary>
        /// Рассчитать произведение факториалов 1! * 2! * 3! * ... * n!
        /// возведением в степень 1^n * 2^(n-1) * 3^(n-2) * ... * n^1
        /// </summary>
        /// <param name="n"> Произведение факториалов </param>
        /// <returns></returns>
        public static double FactMul2(int n)
        {
            var result = 1.0;
            for (int i = 2; i < n; i++)
            {
                result *= Math.Pow(i, n - i + 1);
            }
            return result * n;
        }
    }
}
