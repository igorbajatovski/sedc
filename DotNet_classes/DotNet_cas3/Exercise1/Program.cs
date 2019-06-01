using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number:");
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; ++i)
                Console.WriteLine("i = " + i);

            Console.Write("Enter number:");
            count = int.Parse(Console.ReadLine());

            for (int i = count; i >= 1; --i)
                Console.WriteLine("i = " + i);

            Console.ReadLine();
        }
    }
}
