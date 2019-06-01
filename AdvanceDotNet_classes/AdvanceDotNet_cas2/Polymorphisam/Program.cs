using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphisam
{
    class PrintData
    {
        public void Print(int i)
        {
            Console.WriteLine("Type int: {0}", i);
        }

        public void Print(decimal i)
        {
            Console.WriteLine("Type int: {0}", i);
        }

        public void Print(double i)
        {
            Console.WriteLine("Type int: {0}", i);
        }

        public void Print<T>(IEnumerable<T> list)
        {
            foreach (T elem in list)
            {
                Console.WriteLine("\t{0}", elem);
            }
            Console.WriteLine("\n");
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            #region static polymorphisam

            //PrintData pd = new PrintData();
            //pd.Print(100);
            //pd.Print(100.5M);
            //pd.Print(100.5);

            //List<string> strings = new List<string> { "Igor", "Dejan", "Blas" };
            //pd.Print(strings);
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    { "65465465465", "Blas" },
            //    { "55465464664", "Igor" },
            //    { "45787878744", "Dejan" }
            //};
            //pd.Print(dic);

            //Dictionary<int, string> dic1 = new Dictionary<int, string>()
            //{
            //    { 1, "Blas" },
            //    { 2, "Igor" },
            //    { 3, "Dejan" }
            //};
            //pd.Print(dic1);
            #endregion

            #region Dynamc Polymorphisam

            //Car car1 = new Car();
            //Car car2 = new Car("65465465FGF44FGD");
            //Console.WriteLine(car1.MotorNumber);
            //car1.Refuel();
            //Console.WriteLine("----------------------");
            //Console.WriteLine(car2.MotorNumber);
            //car2.Refuel();
            //Console.WriteLine("----------------------");

            //ElectricCar eCar1 = new ElectricCar();
            //ElectricCar eCar2 = new ElectricCar("654654DFSG654SDG");
            //Console.WriteLine(eCar1.MotorNumber);
            //eCar1.Refuel();
            //Console.WriteLine("----------------------");
            //Console.WriteLine(eCar2.MotorNumber);
            //eCar2.Refuel();
            //Console.WriteLine("----------------------");

            //ICar[] cars =
            //{
            //    new Car("DDGS65466GSF4"),
            //    new ElectricCar("FHGDHFD546HRE", 120, 8),
            //    new HybridCar("SFRRBF4554FHGDHG", 140, 5)
            //};

            //foreach(var car in cars)
            //{
            //    Console.WriteLine(car.PrintInfo());
            //    car.Refuel();
            //    Console.WriteLine("----------------------");
            //}

            #endregion

            Console.ReadLine();
        }
    }
}
