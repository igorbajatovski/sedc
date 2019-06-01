using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workshop
{
    public class Director : ManagementStuff
    {
        public override void DoEmployeeApprisal(Employee e)
        {
            //Console.WriteLine($"Director {this.Name}, {this.Surname} has apprised employee {e.Name}, {e.Surname}");
            Logger.Log($"Director {this.Name}, {this.Surname} has apprised employee {e.Name}, {e.Surname}");
        }

        public override void PromoteEmployee(Employee e)
        {
            //Console.WriteLine($"Director {this.Name}, {this.Surname} has promoted employee {e.Name}, {e.Surname}");
            Logger.Log($"Director {this.Name}, {this.Surname} has promoted employee {e.Name}, {e.Surname}");
        }

        public async override void SendCommunication()
        {
            //Console.WriteLine("Director send emal.");
            Task myTask = new Task(() =>
            {
                Thread.Sleep(7000);
                Logger.Log("Director send emal.");
            });
            myTask.Start();
            await myTask;
        }
    }
}
