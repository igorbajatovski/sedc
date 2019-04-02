using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = "Madam I'm Adam";
            Console.WriteLine(phrase.IsPalindrom());
            phrase = "Madam I am Adam";
            Console.WriteLine(phrase.IsPalindrom());
            phrase = "Refer, refer!";
            Console.WriteLine(phrase.IsPalindrom());

            double numeric = 123.321;
            Console.WriteLine(numeric.IsPalindrom());
            int integer = 11211;
            Console.WriteLine(integer.IsPalindrom());
            long bigInt = 12345654321;
            Console.WriteLine(bigInt.IsPalindrom());

            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static bool IsPalindrom(this string str)
        {
            string strWithLettersAndNumbers = new string(str.Where(c => { if (char.IsLetterOrDigit(c)) return true; return false; }).ToArray()).ToUpper();
            for(int i = 0; i < strWithLettersAndNumbers.Length / 2; ++i)
            {
                if (strWithLettersAndNumbers[i] != strWithLettersAndNumbers[strWithLettersAndNumbers.Length - i - 1])
                    return false;
            }

            return true;
        }

        public static bool IsPalindrom(this double num)
        {
            while(num %  1 != 0)
                num *= 10;

            return num.ToString().IsPalindrom();
        }

        public static bool IsPalindrom(this int num)
        {
            return num.ToString().IsPalindrom();
        }

        public static bool IsPalindrom(this long num)
        {
            return num.ToString().IsPalindrom();
        }
    }
}
