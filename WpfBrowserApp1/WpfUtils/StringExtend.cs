using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfUtils
{
    public static class StringExtend
    {
        public static string ReplaceBlank(this string str)
        {
            string dest = str;
            if (str != null)
            {
                dest = Regex.Replace(str, @"\\s*|\t|\r|\n", "");
            }
            return dest;
        }
    }
}
