using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Pero";
            string s2 = "Teftero";
            string result1 = s1 + " " + s2;
            Console.WriteLine(result1);
            string sNumber1 = "9";
            string sNumber2 = "3";
            string result2 = sNumber1 + sNumber2;
            Console.WriteLine(result2);

            int intVariable = 56;
            string strVariable = "Text";
            string strResult = intVariable + strVariable;
            var strResult1 = intVariable + strVariable;
            Console.WriteLine(strResult);
            Console.WriteLine(strResult1);
            Console.ReadLine();
        }
    }
}
