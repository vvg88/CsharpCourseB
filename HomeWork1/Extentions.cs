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
            var indxOfE = originalStr.IndexOf(oldSubStr, StringComparison.InvariantCultureIgnoreCase);
            if (indxOfE != -1)
            {
                var eMinusStr = originalStr.Substring(indxOfE, 2);
                var sb = new StringBuilder(originalStr);
                sb.Replace(eMinusStr, newSubStr);
                originalStr = sb.ToString();
            }
            return originalStr;
        }
    }
}
