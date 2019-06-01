using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;

            Console.Write("Enter the first number: ");
            if (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.Write("You did not enter number!!!. Press any key to exit the application...");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter the second number: ");
            if (!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.Write("You did not enter number!!!. Press any key to exit the application...");
                Console.ReadLine();
                return;
            }

            int tmp;
            tmp = num1;
            num1 = num2;
            num2 = tmp;

            Console.WriteLine();
            Console.WriteLine("After Swapping:");
            Console.WriteLine("First Number: " + num1);
            Console.WriteLine("Second Number: " + num2);
            Console.WriteLine();
            Console.Write("Press any key to exit the application...");
            Console.ReadLine();
        }
    }
}
