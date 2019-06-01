using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Program
    {

        public static void Print<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            foreach(var prop in props)
                Console.Write($"{prop.Name}\t");
            Console.Write("\n");
            
            foreach(var elem in collection)
            {
                foreach (var prop in props)
                {
                    Console.Write($"{prop.GetValue(elem)}\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            #region Static classes and extension methods
            //double gallon = 10;
            //Console.WriteLine("{0} galons = {1} litre", gallon, GallonsToLiterConverter.GallonsToLiter(gallon));

            //double litre = 5.5;
            //Console.WriteLine("{0} litre = {1} galon", litre, GallonsToLiterConverter.LiterToGallons(litre));

            //string str = "Hi there, how are you?";
            //Console.WriteLine(str.Shorten(8));
            //Console.WriteLine(str.QuoteString());

            //string name = "igor";
            //Console.WriteLine(name.FirstLetterCapitol());
            #endregion

            #region partial classes
            //Customer cust = new Customer() { Name = "Blagoj Policaecot", Address = "MVR - Skopje" };
            //cust.Print();
            #endregion

            #region Nested Classes
            //Order order = new Order();
            //order.AddOrderLine("Pivo - Kozel Temno", 10, 80);
            //order.AddOrderLine("Rakija - Zolta Tikves", 25, 400);
            //order.AddOrderLine("Mastika", 12, 300);
            //order.AddOrderLine("Konjak - Badel", 14, 450);
            //order.AddOrderLine("Viski - Skotsko", 18, 1200);
            //Console.WriteLine("Total amount of the orders is {0} denars", order.OrderTotal());
            #endregion

            List<BankCustomer> customers = new List<BankCustomer>()
            {
                new BankCustomer(){ Name = "Customer1", City = "Skopje", Balance = 1000, Address = "Adresa1" },
                new BankCustomer(){ Name = "Customer2", City = "Veles", Balance = 2000, Address = "Adresa2" }
            };

            Print(customers);

            Dictionary<int, BankCustomer> dic = new Dictionary<int, BankCustomer>()
            {
                { 1 ,  new BankCustomer(){ Name = "Customer1", City = "Skopje", Balance = 1000, Address = "Adresa1" } },
                { 2,  new BankCustomer(){ Name = "Customer2", City = "Veles", Balance = 2000, Address = "Adresa2" } }
            };

            Print(dic.Values);

            Console.ReadLine();
        }
    }
}
