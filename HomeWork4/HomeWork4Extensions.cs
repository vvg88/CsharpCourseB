using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    static class HomeWork4Extensions
    {
        public static int Age(this DateTime date)
        {
            return DateTime.Today.Year - date.Year;
        }

        public static IEnumerable<string> DatesToStrings(this IEnumerable<DateTime> dates)
        {
            return dates.Select(date => $"{date.Day}.{(date.Month < 10 ? $"0{date.Month}" : $"{date.Month}")}.{date.Year}");
        }
    }
}
