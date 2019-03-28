using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfEven
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[6];
            int numbersRead = 0;
            do
            {
                Console.WriteLine($"Enter number {numbersRead+1}");
                int readNum;
                if (Int32.TryParse(Console.ReadLine(), out readNum))
                    numbers[numbersRead++] = readNum;
                else
                    Console.WriteLine("You did not enter a number!!!");
            } while (numbersRead < 6);

            int evenSum = 0;
            foreach(int number in numbers)
            {
                if (number % 2 == 0)
                    evenSum += number;
            }

            Console.WriteLine($"The sum of the even numbers is {evenSum}");
            Console.ReadLine();
        }
    }
}
