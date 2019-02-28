using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[0];
            string line = "";
            do
            {
                Console.Write("Enter name: ");
                line = Console.ReadLine();
                if (line != "N")
                {
                    Array.Resize(ref names, names.Length + 1);
                    names[names.Length - 1] = line;
                }
            } while (line != "N");

            for(int i = 0; i < names.Length; ++i)
            {
                if(i < names.Length - 1)
                    Console.Write(names[i] + ",");
                else
                    Console.Write(names[i]);
            }

            Console.ReadLine();
        }
    }
}
