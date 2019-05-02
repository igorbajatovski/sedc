using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            //SendMessge("Hello there, we are SEDC students!");
            /*
            Task x = SendMessgeAsync("Hello there, we are SEDC students!");
            Console.WriteLine($"{x.Status}");
            ShowAd("Shampoo");
            
            Console.ReadLine();
            */
            Task t = MainThread();
            Console.WriteLine("Maint thread is started");
            Console.ReadLine();
        }

        public static async Task MainThread()
        {
            await SendMessgeAsync("Hello there, we are SEDC students!");
            ShowAd("Potato");
            Console.ReadLine();
        }

        public static void SendMessge(string message)
        {
            Console.WriteLine("Sending message...");
            Thread.Sleep(5000);
            Console.WriteLine($"The message '{message}' is sent!");
        }

        public static async Task SendMessgeAsync(string message)
        {
            Console.WriteLine("Sending message...");
            await Task.Run( () =>
            {
                Thread.Sleep(7000);
                Console.WriteLine($"The message '{message}' is sent!");
            });
        }

        public static void ShowAd(string commercialProduct)
        {
            Console.WriteLine("While you are waiting, let us show our ad:");
            Console.WriteLine("Buy the best product in the world");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(commercialProduct);
            Console.ResetColor();
            Console.WriteLine(" now and get ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("FREE");
            Console.ResetColor();
            Console.WriteLine("shipping");
        }
    }
}

