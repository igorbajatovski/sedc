using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    interface IInterface
    {
        int met1();
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string endsWithE = strings.First(str => str.EndsWith("e"));
            Console.WriteLine("The first string ending with 'e' is {0}", endsWithE);
            string endsWithE2 = strings.First(str => str.EndsWith("ee"));
            Console.WriteLine("The first string ending with 'ee' is {0}", endsWithE2);

            var equal = strings.Where((str, index) => str.Length == index);
            Console.WriteLine(string.Join(", ", equal));

            var threeDigitNumbers = Enumerable.Range(100, 999);
            var arr = threeDigitNumbers.Where(n => DividesDigitsSum(n));
            Console.WriteLine(string.Join(", ", arr));

            Console.ReadLine();
        }

        public static bool DividesDigitsSum(int n)
        {
            int sum = 0;
            int bkpN = n;
            while (n > 0)
            {
                int digit = n % 10;
                sum += digit;
                n /= 10;
            }

            return bkpN % sum == 0;
        }
    }
}
