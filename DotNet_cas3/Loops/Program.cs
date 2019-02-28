using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            #region For
            // For loops
            //for(int i = 0; i <= 10; ++i)
            //{
            //    Console.WriteLine("i = " + i);
            //    string word = Console.ReadLine();
            //    Console.WriteLine("Your word was: " + word);
            //}
            //Console.WriteLine("Creating droid army...");
            //for(int i = 1; i <= 10; ++i)
            //{
            //    Console.WriteLine("Assembling droid number:" + i);
            //    if(i == 7)
            //    {
            //        Console.WriteLine("Assembling not successfull!");
            //        continue;
            //    }

            //    if(i == 9)
            //    {
            //        Console.WriteLine("Machine broke down");
            //        break;
            //    }
            //    Console.WriteLine("Droid " + i + " created!");
            //    Console.ReadLine();
            //}
            #endregion

            #region While
            //int counter = 0;
            //while (counter <= 5)
            //{
            //    Console.WriteLine("Counter is " + counter);
            //    counter++;
            //}
            Console.WriteLine("Press X to close the application!");
            string textLine = "";
            while((textLine = Console.ReadLine()) != "X")
            {
                Console.WriteLine("Executing importan code...");
                Console.WriteLine(textLine);
            }
            #endregion

            #region Do While

            #endregion

            //Console.ReadLine();
        }
    }
}
