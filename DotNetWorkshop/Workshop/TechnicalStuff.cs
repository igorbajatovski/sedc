using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Interfaces;

namespace Workshop
{
    public class TechnicalStuff : Employee, IWorkable, IEatable
    {
        public void Eat()
        {
            Console.WriteLine($"Technican {this.Name}, {this.Surname} is eating.");
        }

        public void MaintainSystems()
        {
            Console.WriteLine($"{this.Name}, {this.Surname} is maintaning the systems");
        }

        public void Work()
        {
            Console.WriteLine($"Technican {this.Name}, {this.Surname} is working.");
        }
    }
}
