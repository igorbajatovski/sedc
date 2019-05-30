using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int integerVariable1 = 5;
            int integerVariable2;
            integerVariable2 = -100;
            integerVariable2 = 12;
            float floatVariable = 2.5f;
            double doubleVariable = 2.5;
            string stringVariable = "Hello SEDC!";
            char characterVariable = '^';
            bool boolVariable = true;
            long longerInteger = 5465465435321321324;
            int sumOfTwoNumber = 2 + 6;
            sumOfTwoNumber += 12;
            bool isGreater = 6 > 12;
            Console.WriteLine(isGreater);
            bool someExpression = true;
            someExpression &= isGreater;
            Console.WriteLine(isGreater);
            var x = 5;
            //Console.WriteLine(sumOfTwoNumber);
            //Console.WriteLine(integerVariable1);
            //Console.WriteLine(integerVariable2);
            Console.ReadLine();
        }
    }
}
