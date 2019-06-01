using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArray = { "Blagoj", "Jadi", "Samo", "Svinsko", "i e debel" };
            double[] decimalArray = { 3.14, 6.45465, 5.0, 125.8787, 5.0/45466.0 };

            char[] charArray = new char[5];
            for(int i = 0; i < charArray.Length; ++i)
            {
                char c = Console.ReadKey().KeyChar;
                charArray[i] = c;
            }

            bool[] boolArray = { true, true, false, false, false };

            Console.WriteLine();
            Array[] arrayArray = { new int[2] { 5, 6 } , new int[2] { 10, 5 }, new int[2] { 78, 98 }, new int[2] { 1, 2 }, new int[2] { 6, 6 } };

            foreach(Array elem in arrayArray)
            {
                foreach (int i in elem)
                    Console.WriteLine(i);
            }

            Console.WriteLine();
            int[][] matrix = { new int[] { 1, 2 },
                               new int[] { 3, 4 },
                               new int[] { 5, 6 },
                               new int[] { 7, 8 },
                               new int[] { 9, 10 } };
            Console.WriteLine(matrix[0][1]);

            Console.ReadLine();
        }
    }
}
