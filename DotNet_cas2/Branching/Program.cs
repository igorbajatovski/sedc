using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branching
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 25;
            int num2 = 34;
            if (num1 > num2)
                Console.WriteLine("The first number is larger");
            else if(num2 > num1)
                Console.WriteLine("The second number is larger");
            else
                Console.WriteLine("The numbers are equal");

            //Exercise5
            Console.Write("Enter the number of apple trees:");
            int numberOfTrees = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of apples per branch:");
            int numberOfApplesPerBranch = int.Parse(Console.ReadLine());
            Console.Write("Enter the amount of apples a basket can hold:");
            int bascketAmmount = int.Parse(Console.ReadLine());

            int totalBaskets = (numberOfTrees * 12 * numberOfApplesPerBranch) / bascketAmmount;
            Console.Write("Total baskets: " + totalBaskets);
            Console.ReadLine();
        }
    }
}
