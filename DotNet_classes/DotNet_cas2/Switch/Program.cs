using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 2;
            switch (day)
            {
                case 1: Console.WriteLine("It's Monday");
                    break;
                case 2:
                    Console.WriteLine("It's Tuesday");
                    break;
                case 3:
                    Console.WriteLine("It's Wednesday");
                    break;
                case 4:
                    Console.WriteLine("It's Thursday");
                    break;
                case 5:
                    Console.WriteLine("It's Friday");
                    break;
                case 6:
                    Console.WriteLine("It's Saturday");
                    break;
                case 7:
                    Console.WriteLine("It's Sunday");
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }


            int input;
            Console.Write("Enter number: ");
            int.TryParse(Console.ReadLine(), out input);

            switch(input)
            {
                case 1:
                    Console.WriteLine("You got a new car");
                    break;
                case 2:
                    Console.WriteLine("You got a new plane");
                    break;
                case 3:
                    Console.WriteLine("You got a new bike");
                    break;
                default:
                    Console.WriteLine("Wrong input. Allowed values are 1, 2 and 3");
                    break;
            }

            Console.ReadLine();
        }
    }
}
