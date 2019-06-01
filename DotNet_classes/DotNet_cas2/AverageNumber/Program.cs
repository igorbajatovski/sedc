using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            int num3;
            int num4;

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

            Console.Write("Enter the third number: ");
            if (!int.TryParse(Console.ReadLine(), out num3))
            {
                Console.Write("You did not enter number!!!. Press any key to exit the application...");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter the fourth number: ");
            if (!int.TryParse(Console.ReadLine(), out num4))
            {
                Console.Write("You did not enter number!!!. Press any key to exit the application...");
                Console.ReadLine();
                return;
            }

            int result = (num1 + num2 + num3 + num4) / 4;
            Console.WriteLine("The average of " + num1 + ", " + num2 + ", " + num3 + ", and " + num4 + " is: " + result);
            Console.Write("Press any key to exit the application...");
            Console.ReadLine();
        }
    }
}
