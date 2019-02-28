using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[5];
            for (int i = 0; i < intArray.Length; ++i)
            {
                int elem;
                Console.Write("Enter number: ");
                int.TryParse(Console.ReadLine(), out elem);
                intArray[i] = elem;
            }

            int sum = intArray.Sum();

            Console.WriteLine("The sum of the elements is: " + sum);
            Console.ReadLine();
        }
    }
}
