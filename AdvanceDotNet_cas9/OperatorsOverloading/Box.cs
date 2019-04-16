using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsOverloading
{
    public class Box
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }

        public Box() { }

        public Box(int width, int height, int length)
        {
            this.Width = width;
            this.Height = height;
            this.Length = length;
        }

        public int Volume()
        {
            return Width * Height * Length;
        }

        public int Area()
        {
            return Width * Length * 2 + Width * Height * 2 + Height * Length * 2;
        }

        public static Box operator +(Box box1, Box box2)
        {
            return new Box(box1.Width + box2.Width, box1.Height + box2.Height, box1.Length + box2.Length);
        }

        public static Box operator -(Box box1, Box box2)
        {
            return new Box(box1.Width - box2.Width, box1.Height - box2.Height, box1.Length - box2.Length);
        }
        static int i;
        public static Box operator ++(Box a)
        {
            Console.WriteLine("i = {0}", ++i);
            return new Box(a.Width + 1, a.Height + 1, a.Length + 1);
        }

        public static Box operator --(Box a)
        {
            return new Box(a.Width - 1, a.Height - 1, a.Length - 1);
        }

        public static bool operator ==(Box box1, Box box2)
        {
            return box1.Width == box2.Width && box1.Height == box2.Height && box1.Length == box2.Length;
        }

        public static bool operator !=(Box box1, Box box2)
        {
            return box1.Width != box2.Width || box1.Height != box2.Height || box1.Length != box2.Length;
        }

        public static bool operator !(Box box)
        {
            return (box.Width == 0 && box.Height == 0 && box.Length == 0);
        }

        public static bool operator &(Box box1, Box box2)
        {
            bool flag1 = (box1.Width == 0 && box1.Height == 0 && box1.Length == 0);
            bool flag2 = (box2.Width == 0 && box2.Height == 0 && box2.Length == 0);

            return flag1 & flag2;
        }

        public static bool operator |(Box box1, Box box2)
        {
            bool flag1 = (box1.Width == 0 && box1.Height == 0 && box1.Length == 0);
            bool flag2 = (box2.Width == 0 && box2.Height == 0 && box2.Length == 0);

            return flag1 | flag2;
        }


    }
}

