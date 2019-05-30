using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    static class ExtensionMethods
    {
        public static string Shorten(this string str, int length)
        {
            return str.Substring(0, length);
        }

        public static string QuoteString(this string str)
        {
            return '"' + str + '"';
        }

        public static string FirstLetterCapitol(this string str)
        {
            string firstLetter = str.Substring(0, 1).ToUpper();
            return firstLetter + str.Substring(1);
        }
    }
}
