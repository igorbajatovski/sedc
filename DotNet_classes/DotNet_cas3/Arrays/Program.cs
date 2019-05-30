using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringsArray = new string[2] { "Blas", "Igor" };
            stringsArray[0] = "Silent Bob";
            stringsArray[1] = "John Doe";

            foreach(string elem in stringsArray)
                Console.WriteLine(elem);

            Console.WriteLine();

            stringsArray[1] = "James Bond";
            foreach (string elem in stringsArray)
                Console.WriteLine(elem);

            Console.WriteLine();
            int[] intArray = new int[] {2, 4, -436};    
            foreach (int elem in intArray)
                Console.WriteLine(elem);

            Console.WriteLine();
            bool[] boolArray = { true, false, true, false, false };
            foreach (bool elem in boolArray)
                Console.WriteLine(elem);

            Console.WriteLine();
            double[] doubleArray = new double[3];
            foreach (double elem in doubleArray)
                Console.WriteLine(elem);

            Console.WriteLine();
            Console.WriteLine(doubleArray.Length);
            Console.WriteLine(boolArray.Length);

            string[] names = { "Bob", "Jill", "Kenny", "March" };
            Console.WriteLine("Before reverse");
            foreach (string elem in names)
                Console.WriteLine(elem);
            Array.Reverse(names);
            Console.WriteLine("After reverse");
            foreach (string elem in names)
                Console.WriteLine(elem);

            Console.WriteLine();
            int nameFound = Array.IndexOf(names, "Kenny");
            if(nameFound > -1)
                Console.WriteLine(names[nameFound]);

            Array.Resize(ref names, names.Length + 5);
            Console.WriteLine(names.Length);

            Console.WriteLine();
            foreach (string elem in names)
                Console.WriteLine(elem);

            Console.ReadLine();
        }
    }
}
