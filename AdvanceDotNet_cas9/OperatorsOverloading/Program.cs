using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsOverloading
{
    class Program
    {


        static void Main(string[] args)
        {
            Box box1 = new Box(1,1,1);
            Console.WriteLine("Box1 Volume: {0}", box1.Volume());
            Console.WriteLine("Box1 Area: {0}", box1.Area());

            Box box2 = new Box(1, 2, 3);
            Console.WriteLine("Box2 Volume: {0}", box2.Volume());
            Console.WriteLine("Box2 Area: {0}", box2.Area());

            Box box3;
            box3 = box1 + box2;
            Console.WriteLine("Box3 Volume: {0}", box3.Volume());
            Console.WriteLine("Box3 Area: {0}", box3.Area());

            Box box4 = box2 - box1;
            Console.WriteLine("Box4 Volume: {0}", box4.Volume());
            Console.WriteLine("Box4 Area: {0}", box4.Area());

            Box box5 = box1++;
            Console.WriteLine("Box5 Volume: {0}", box5.Volume());
            Console.WriteLine("Box5 Area: {0}", box5.Area());

            Box box6 = --box3;
            Console.WriteLine("Box6 Volume: {0}", box6.Volume());
            Console.WriteLine("Box6 Area: {0}", box6.Area());

            if(box1 == box3)
                Console.WriteLine("Box1 and Box3 are same");
            else
                Console.WriteLine("Box1 and Box3 are different");

            Box box7 = new Box(1, 1, 1);

            if (--box1 == box5)
                Console.WriteLine("Box1 and Box5 are same");
            else
                Console.WriteLine("Box1 and Box5 are different");

            if (box1.Equals(box5))
                Console.WriteLine("Box1 and Box5 are same by ref");
            else
                Console.WriteLine("Box1 and Box5 are different by ref");

            bool b = false;
            if(!b)
            {
                Console.WriteLine("true");
            }

            Box box8 = new Box(0, 0, 0);
            if(!box8)
            {
                Console.WriteLine("Not a box");
            }

            Console.ReadLine();
        }
    }
}
