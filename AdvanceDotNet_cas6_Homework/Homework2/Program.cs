using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = "BOOKKEEPER";
            List<char> passedCharacters = new List<char>();
            foreach(char letter in inputString)
            {
                if(!passedCharacters.Contains(letter))
                {
                    passedCharacters.Add(letter);
                    var howManyTimes = inputString.Where(e => e == letter).Count();
                    Console.WriteLine($"Character {letter}: {howManyTimes} time/s");
                }
            }

            Console.ReadLine();
        }
    }
}
