using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracPolymorphisam
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Console.WriteLine(dog.Describe());
            Console.WriteLine(dog.Features());


            Bird bird = new Bird();
            Console.WriteLine(bird.Describe());
            Console.WriteLine(bird.Features());

            Console.ReadLine();
        }
    }
}
