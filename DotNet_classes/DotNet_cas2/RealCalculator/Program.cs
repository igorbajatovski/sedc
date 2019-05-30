using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;

            Console.Write("Enter the first number: ");
            if(!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.Write("You did not enter number!!!. Press any key to exit the application...");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter the second number: ");
            if(!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.Write("You did not enter number!!!. Press any key to exit the application...");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter the operation: ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "+":
                    {
                        int result = num1 + num2;
                        Console.WriteLine("The result is: " + result);
                        Console.WriteLine("Press any ket to exit the application...");
                        Console.ReadLine();
                        break;
                    }
                case "-":
                    {
                        int result = num1 - num2;
                        Console.WriteLine("The result is: " + result);
                        Console.WriteLine("Press any ket to exit the application...");
                        Console.ReadLine();
                        break;
                    }
                case "/":
                    {
                        int result = num1 / num2;
                        Console.WriteLine("The result is: " + result);
                        Console.WriteLine("Press any ket to exit the application...");
                        Console.ReadLine();
                        break;
                    }
                case "*":
                    {
                        int result = num1 * num2;
                        Console.WriteLine("The result is: " + result);
                        Console.WriteLine("Press any ket to exit the application...");
                        Console.ReadLine();
                        break;
                    }
                default:
                    Console.Write("Allowed operations are +,-,/,*. Press any key to exit the application...");
                    Console.ReadLine();
                    break;
            }

        }
    }
}
