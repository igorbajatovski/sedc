using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracPolymorphisam
{
    class Program
    {   
        class Caller
        {
            public static void CalerArea(Shape shape)
            {
                Console.WriteLine("Area is {0}", shape.Area());
            }
        }

        static void Main(string[] args)
        {
            //Dog dog = new Dog();
            //Console.WriteLine(dog.Describe());
            //Console.WriteLine(dog.Features());


            //Bird bird = new Bird();
            //Console.WriteLine(bird.Describe());
            //Console.WriteLine(bird.Features());

            Shape shape1 = new Shape();
            Shape shape2 = new Shape(2, 3);
            Caller.CalerArea(shape1);
            Caller.CalerArea(shape2);

            Rectangle rec1 = new Rectangle();
            Rectangle rec2 = new Rectangle(5, 6);
            Caller.CalerArea(rec1);
            Caller.CalerArea(rec2);

            Triangle t1 = new Triangle();
            Triangle t2 = new Triangle(7, 6);
            Caller.CalerArea(t1);
            Caller.CalerArea(t2);

            Circle c1 = new Circle();
            Circle c2 = new Circle(6);
            Caller.CalerArea(c1);
            Caller.CalerArea(c2);

            Console.ReadLine();
        }
    }
}
