using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    public class Manager : ManagementStuff
    {
        public override void DoEmployeeApprisal(Employee e)
        {
            Console.WriteLine($"Manager {this.Name}, {this.Surname} has apprised employee {e.Name}, {e.Surname}");
        }

        public override void PromoteEmployee(Employee e)
        {
            Console.WriteLine($"Manager {this.Name}, {this.Surname} has promoted employee {e.Name}, {e.Surname}");
        }

        public override void SendCommunication()
        {
            Console.WriteLine("Manger send sms message.");
        }
    }
}
