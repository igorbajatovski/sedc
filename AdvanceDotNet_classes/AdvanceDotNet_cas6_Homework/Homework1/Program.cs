using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1,4,6,8,9,2,34,5,6,2,7,9,1,6,0,9,7,6,54,3,2 };
            List<int> passedNumbers = new List<int>();
            foreach(var elem in numbers)
            {
                if (!passedNumbers.Contains(elem))
                {
                    passedNumbers.Add(elem);
                    var howManyTimes = numbers.Where(e => e == elem).Count();
                    Console.WriteLine($"Number {elem} appears {howManyTimes} time/s");
                }
            }

            Console.ReadLine();
        }
    }
}
