using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int credits = 102;
            int messageCredit = 5;
            int smsNumber = credits / messageCredit;
            Console.WriteLine(smsNumber);
            Console.ReadLine();
        }
    }
}
