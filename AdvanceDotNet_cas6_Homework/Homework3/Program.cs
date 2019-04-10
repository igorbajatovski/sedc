using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number of members on the list : ");
            int numOfElem;
            while (!int.TryParse(Console.ReadLine(), out numOfElem))
            {
                Console.WriteLine("Entered value is not a number!");
                Console.Write("Input the number of members on the list : ");
            }

            List<int> numbers = new List<int>();
            for(int i = 0; i < numOfElem; ++i)
            {
                Console.Write($"Member {i}: ");
                int member;
                while (!int.TryParse(Console.ReadLine(), out member))
                {
                    Console.WriteLine("Entered value is not a number!");
                    Console.Write($"Member {i}: ");
                }
                numbers.Add(member);
            }

            Console.Write("Input the value above you want to display the members of the list : ");
            int above;
            while (!int.TryParse(Console.ReadLine(), out above))
            {
                Console.WriteLine("Entered value is not a number!");
                Console.Write("Input the value above you want to display the members of the list : ");
            }

            var aboveNumbers = numbers.Where(e => e > above);

            Console.WriteLine("The numbers greater than {0} are : ", above);
            Console.WriteLine(string.Join("\n", aboveNumbers.ToArray()));

            Console.ReadLine();
        }
    }
}
