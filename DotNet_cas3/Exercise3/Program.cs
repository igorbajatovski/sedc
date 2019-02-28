using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number:");
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; ++i)
            {
                if (i == 100)
                    break;

                if (i % 3 == 0 || i % 7 == 0)
                    continue;
                Console.WriteLine("Number " + i + " is not devisable by 3 or 7");
            }

            Console.ReadLine();
        }
    }
}
