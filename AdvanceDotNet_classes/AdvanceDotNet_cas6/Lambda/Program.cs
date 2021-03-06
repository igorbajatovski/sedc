﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {

        delegate int lambda(int input);
        delegate long multiply(int x, int y, int z);
        delegate int nonParamsLambda();

        static void Main(string[] args)
        {
            lambda addOne = x => x + 1;
            Console.WriteLine(addOne(5));

            nonParamsLambda random = () =>
            {
                int ran = new Random().Next();
                Console.WriteLine("Random number {0}", ran);
                return ran;
            };

            int myRandom = random();

            Action line = () => Console.WriteLine();
            var numbers = Enumerable.Range(10, 90);
            Console.WriteLine(string.Join(" ", numbers));

            long[] nums = { 1, 2, 3, 4, 5 };
            var parni_long = nums.Where(e => e % 2 == 0);

            var parni = numbers.Where(e => e % 2 == 0);
            var neparni = numbers.Where(e => e % 2 != 0);

            line();
            Console.WriteLine(string.Join(" ", parni));
            line();
            Console.WriteLine(string.Join(" ", neparni));


            var parni5 = numbers.Where(e => e % 2 == 0 && e % 5 == 0);
            var neparni5 = numbers.Where(e => e % 2 != 0 && e % 5 == 0);

            line();
            Console.WriteLine(string.Join(" ", parni5));
            line();
            Console.WriteLine(string.Join(" ", neparni5));

            Console.ReadLine();
        }
    }
}
