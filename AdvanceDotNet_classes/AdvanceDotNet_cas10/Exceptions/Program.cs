using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class MultuExceptions
    {
        private void ExcpetionCollection(int input1, int input2)
        {
            List<Exception> exceptions = new List<Exception>();
            if(input1 == 1)
            {
                exceptions.Add(new ArgumentException("New argument exception"));
            }

            if(input2 == 2)
            {
                exceptions.Add(new NullReferenceException("Null ref. exception"));
            }

            int i = 0, j = 0;
            try
            {
                int k = i/ j;
            }
            catch(DivideByZeroException ex)
            {
                exceptions.Add(ex);
            }

            if(exceptions.Any())
            {
                throw new AggregateException("This is aggregated exception", exceptions);
            }

        }


        public void Run()
        {
            try
            {
                this.ExcpetionCollection(1, 2);
            }
            catch(AggregateException ex)
            {
                foreach(var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++ Exceptions ++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            int num = 10;
            int devisor = 0;
            int calculated;

            try
            {
                calculated = num / devisor;
            }
            catch (Exception ex)
            {
                ex.HelpLink = "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch";
                Console.WriteLine("HelpLink: " + ex.HelpLink);
                Console.WriteLine("HResult: " + ex.HResult);
                Console.WriteLine("InnerException: " + ex.InnerException);
                Console.WriteLine("Source: " + ex.Source);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("TargetSite: " + ex.TargetSite);
                Console.WriteLine("Data: " + ex.Data);
                Console.WriteLine("Message: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Clearing up some resources...");
            }

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++ Multi Exceptions +++++++++++++++++++++++++++++++++++++++++++++++++");

            MultuExceptions me = new MultuExceptions();
            me.Run();

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++ File Exceptions +++++++++++++++++++++++++++++++++++++++++++++++++");

            try
            {
                string path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas10\test.txt";
                System.IO.File.ReadAllText(path);
            }
            catch(System.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
