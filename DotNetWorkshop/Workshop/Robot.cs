using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Interfaces;

namespace Workshop
{
    public class Robot : Employee, IWorkable
    {
        public void MaintaingDatawareHouse()
        {
            Console.WriteLine($"{this.Name}, {this.Surname} is maintaning the the data warehouse");
        }

        public void Work()
        {
            Console.WriteLine($"{this.Name}, {this.Surname} is working on the data warehouse");
        }
    }
}
