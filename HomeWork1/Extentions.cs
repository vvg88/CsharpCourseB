using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    static class Extentions
    {
        public static string ReplaceIfContains(this string originalStr, string oldSubStr, string newSubStr)
        {
            return new StringBuilder(originalStr).ReplaceIfContains(oldSubStr, newSubStr).ToString();
        }

        public static StringBuilder ReplaceIfContains(this StringBuilder originalStr, string oldSubStr, string newSubStr)
        {
            var indxOfE = originalStr.ToString().IndexOf(oldSubStr, StringComparison.InvariantCultureIgnoreCase);
            if (indxOfE != -1)
            {
                originalStr.Replace(oldSubStr, newSubStr);
            }
            return originalStr;
        }
    }
}
