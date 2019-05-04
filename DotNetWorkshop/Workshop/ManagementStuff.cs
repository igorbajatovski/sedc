using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Interfaces;

namespace Workshop
{
    public abstract class ManagementStuff : Employee, IManagable
    {
        public abstract void DoEmployeeApprisal(Employee e);

        public void Manage()
        {
            Console.WriteLine($"Management employee {this.Name}, {this.Surname} manages the company");
        }

        public abstract void PromoteEmployee(Employee e);
        public abstract void SendCommunication();
    }
}
