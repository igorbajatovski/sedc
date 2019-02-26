using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryAndConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some number:");
            //var result = int.Parse(Console.ReadLine());
            //string input1 = Console.ReadLine();
            //int parsedResult = int.Parse(input1);
            //int convertedResult = Convert.ToInt32(input1);
            int tryParsedResult;
            if(int.TryParse(input1, out tryParsedResult))
                Console.WriteLine("The value " + tryParsedResult + " is of type: " + tryParsedResult.GetType());
            else
                Console.WriteLine("Not a number entered.");
            Console.ReadLine();
        }
    }
}
