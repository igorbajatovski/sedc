using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;

            Console.Write("Enter first number:");
            int.TryParse(Console.ReadLine(), out num1);
            Console.Write("Enter second number:");
            int.TryParse(Console.ReadLine(), out num2);

            if (num1 > num2)
                Console.WriteLine("First number is greater then second");
            else if(num2 > num1)
                Console.WriteLine("Second number is greater then first");
            else
                Console.WriteLine("Numbers are equal");

            if (num1 % 2 == 0)
                Console.WriteLine("First number is even");
            else
                Console.WriteLine("First number is odd");

            if (num2 % 2 == 0)
                Console.WriteLine("Second number is even");
            else
                Console.WriteLine("Second number is odd");

            Console.ReadLine();
        }
    }
}
