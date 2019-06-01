using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracPolymorphisam
{
    public class Shape
    {
        protected double a { get; set; } = 1;
        protected double b { get; set; } = 1;
        protected double r { get; set; } = 1;
        public Shape() { }
        public Shape(double x, double y)
        {
            a = x; b = y;
        }
        public Shape(double radius)
        {
            r = radius;
        }

        public virtual double Area()
        {
            Console.WriteLine("Shape area is:");
            return a * b;
        }
    }

    public class Rectangle : Shape
    {   
        public Rectangle() { }

        public Rectangle(double x, double y) : base(x, y)
        {
            a = x; b = y;
        }

        public override double Area()
        {
            Console.WriteLine("Rectangle area is:");
            return a * b;
        }
    }

    public class Triangle : Shape
    {
        public Triangle() { }

        public Triangle(double x, double y) : base(x, y)
        {
            a = x; b = y;
        }

        public override double Area()
        {
            Console.WriteLine("Triangle area is:");
            return (a * b) / 2;
        }
    }

    public class Circle : Shape
    {
        public Circle() { }

        public Circle(double rad) : base(rad)
        {
            r = rad;
        }

        public override double Area()
        {
            Console.WriteLine("Circle area is:");
            return r * r * Math.PI;
        }
    }

}
