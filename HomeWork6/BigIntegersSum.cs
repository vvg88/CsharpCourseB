using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class BigIntegersSum
    {
        /// <summary>
        /// Найти сумму двух больших неотрицательных целых чисел, представленных строками
        /// </summary>
        /// <param name="str1"> Число 1 </param>
        /// <param name="str2"> Число 2 </param>
        /// <returns> Сумма </returns>
        public static string Sum(string str1, string str2)
        {
            if (str1.Any(symb => !char.IsDigit(symb)))
                throw new ArgumentException($"Значение {str1} не является числом!");
            if (str2.Any(symb => !char.IsDigit(symb)))
                throw new ArgumentException($"Значение {str2} не является числом!");

            // Определить строку, которая длиннее
            string longStr, shortStr;
            if (str1.Length >= str2.Length)
            {
                longStr = str1;
                shortStr = str2;
            }
            else
            {
                longStr = str2;
                shortStr = str1;
            }

            var sb = new StringBuilder();
            // Пройти по строкам с конца (младшего разряда)
            for (int i = longStr.Length - 1, j = shortStr.Length - 1, tenFlg = 0; i >= 0; i--, j--)
            {
                uint digit1, digit2;
                if(!uint.TryParse(new string(new[] { longStr[i] }), out digit1))    // Вычислить разряд из длинного слагаемого
                    throw new ArgumentException($"Ошибка при парсинге значения {longStr}");
                if (j >= 0)
                {
                    // Вычислить разряд из второго слагаемого, если оно не закончилось
                    if (!uint.TryParse(new string(new[] { shortStr[j] }), out digit2))
                        throw new ArgumentException($"Ошибка при парсинге значения {shortStr}");
                }
                else
                {
                    digit2 = 0;     // Если закончилось, взять 0
                }

                var sum = digit1 + digit2 + (uint)tenFlg;   // Вычислить сумму с учетом флага переноса
                tenFlg = (int)sum / 10;                     // Вычислить флаг переноса
                sb.Append(sum % 10);                        // Сохранить рассчитанный разряд
            }
            return new string(sb.ToString().Reverse().ToArray());
        }
    }
}
