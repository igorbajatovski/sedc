using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwiatExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Task myTask = MyAsyncMethod();
            Console.WriteLine("Cursor move to next line of execution without waituing for MyAsyncMethod()");
            Console.WriteLine("Now waiting for the task to be finished");
            Task.WaitAll(myTask);
            Console.WriteLine("Exiting command line!");
        }

        public static async Task MyAsyncMethod()
        {
            Task<int> longRunningTask = LongRunningOperation();
            Console.WriteLine("Independent Works of now executes in MyAsyncMethod()");
            int result = await longRunningTask;
            Console.WriteLine("The result is {0}", result);
        }

        public static async Task<int> LongRunningOperation()
        {
            Console.WriteLine("LongRunningOperation() started!");
            await Task.Delay(5000);
            Console.WriteLine("LongRunningOperation() finished after 2 seconds");
            return 1;
        }
    }
}
