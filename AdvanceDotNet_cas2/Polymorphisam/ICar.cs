using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphisam
{
    public interface ICar
    {
        string MotorNumber { get; set; }
        void Refuel();
        string PrintInfo();
    }

    class Car : ICar
    {
        public Car()
        {
            MotorNumber = "0000000000-N";
        }

        public Car(string engineNumber)
        {
            MotorNumber = engineNumber + "-N"; // Normal car
        }

        public string MotorNumber { get; set; }

        public string PrintInfo()
        {
            return MotorNumber;
        }

        public void Refuel()
        {
            Console.WriteLine("Car is refueld with gasoline.");
        }
    }

    class ElectricCar : ICar
    {
        public int BataryLifeMonths { get; set; }
        public int BataryDuration { get; set; }

        public ElectricCar()
        {
            MotorNumber = "0000000000-E";
        }

        public ElectricCar(string engineNumber)
        {
            MotorNumber = engineNumber + "-E"; // Electric car
        }

        public ElectricCar(string engineNumber, int blm, int bd)
        {
            MotorNumber = engineNumber + "-E"; // Electric car
            BataryLifeMonths = blm;
            BataryDuration = bd;
        }

        public string MotorNumber { get; set; }

        public void Refuel()
        {
            Console.WriteLine("Car is refueld with electricity.");
        }

        public string PrintInfo()
        {
            return MotorNumber + " " + BataryLifeMonths + " " + BataryDuration;
        }
    }

    class HybridCar : ICar
    {
        public string MotorNumber { get; set; }
        public int BataryLifeMonths { get; set; }
        public int BataryDuration { get; set; }

        public HybridCar()
        {
            MotorNumber = "00000000000-H";
        }

        public HybridCar(string engineNumber, int blm, int bd)
        {
            MotorNumber = engineNumber + "-H";
            BataryLifeMonths = blm;
            BataryDuration = bd;
        }

        public string PrintInfo()
        {
            return $"{MotorNumber} has batery life of {BataryLifeMonths} months and duration of {BataryDuration}";
        }

        public void Refuel()
        {
            Console.WriteLine("The hybrid car batery is refueld");
        }
    }

}
