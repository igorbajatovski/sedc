using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Interfaces;

namespace Workshop
{
    public class Accountant : Employee, IEatable, IManagable
    {
        public void Eat()
        {
            //Console.WriteLine($"Accountan {this.Name}, {this.Surname} is eating.");
            Logger.Log($"Accountan {this.Name}, {this.Surname} is eating.");
        }

        public void MaintainAccounts()
        {
            //Console.WriteLine($"{this.Name}, {this.Surname} is maintaning the accounts");
            Logger.Log($"{this.Name}, {this.Surname} is maintaning the accounts");
        }

        public void Manage()
        {
            //Console.WriteLine($"{this.Name}, {this.Surname} is managing the company");
            Logger.Log($"{this.Name}, {this.Surname} is managing the company");
        }
    }
}
