using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    static class HomeWork4Extensions
    {
        public static int Age(this DateTime date)
        {
            var years = DateTime.Today.Year - date.Year;
            var newDate = date.AddYears(years);
            return newDate <= DateTime.Today ? years : years - 1;
        }

        public static IEnumerable<string> DatesToStrings(this IEnumerable<DateTime> dates)
        {
            return dates.Select(date => date.ToString("d"));
        }
    }
}
