using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number:");
            int count = int.Parse(Console.ReadLine());

            for(int i = 2; i <= count; ++i)
            {
                if (i % 2 == 0)
                    Console.WriteLine(i + " is even number.");
            }

            Console.Write("Enter number:");
            count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; ++i)
            {
                if (i % 2 != 0)
                    Console.WriteLine(i + " is odd number.");
            }

            Console.ReadLine();
        }
    }
}
