using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        public static int readNumberFromConsole(string msg)
        {
            int num;
            Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Entered value is not a number!");
                Console.Write(msg);
            }
            return num;
        }

        static void Main(string[] args)
        {
            int numOfElem = readNumberFromConsole("Input the number of members on the list : ");

            List<int> numbers = new List<int>();
            for(int i = 0; i < numOfElem; ++i)
            {
                int member = readNumberFromConsole($"Member {i}: ");
                numbers.Add(member);
            }
            
            int above = readNumberFromConsole("Input the value above you want to display the members of the list : ");

            var aboveNumbers = numbers.Where(e => e > above);
            Console.WriteLine("The numbers greater than {0} are : ", above);
            Console.WriteLine(string.Join("\n", aboveNumbers.ToArray()));

            Console.ReadLine();
        }
    }
}
