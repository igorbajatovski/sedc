using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Task myTask = new Task( () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Hello there, after 2000ms");
            });

            myTask.Start();

            Task<string> myName = new Task<string>(() =>
               {
                   Thread.Sleep(5000);
                   Console.WriteLine("Hello from SEDC!");
                   return "Hello my name is Igor";
               });
            myName.Start();
            Console.WriteLine(myName.Result);
            */

            /*
            Task<int> myIntTask = new Task<int>( () =>
            {
                Thread.Sleep(3000);
                return 6;
            });
            myIntTask.Start();

            Task.Run(() =>
           {
               Thread.Sleep(3000);
               Console.WriteLine("This is executed immediately!");
           });
           */

            for(int i = 0; i < 20; ++i)
            {
                int temp = i;
                Task.Run( () =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Task No. {0}", temp);
                });
            }

            Console.ReadLine();
        }
    }
}
