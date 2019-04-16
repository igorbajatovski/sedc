using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    public class Customer : IComparable<Customer>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int MonthlySpend { get; set; }

        public Customer() { }

        public Customer(string name, string address, string city, int monthlySpend)
        {
            Name = name;
            Address = address;
            City = city;
            MonthlySpend = monthlySpend;
        }

        public void PrintCustomer()
        {
            Console.WriteLine($"Customer: {Name}, {Address}, {City}, {MonthlySpend}");
        }

        public override string ToString()
        {
            return $"Customer: {Name}, {Address}, {City}, {MonthlySpend}";
        }

        public int CompareTo(Customer other)
        {
            return this.MonthlySpend.CompareTo(other.MonthlySpend);
        }
    }

    public class CustomerMonthlySpendComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            //if (x.MonthlySpend == y.MonthlySpend)
            //    return 0;
            //else if (x.MonthlySpend > y.MonthlySpend)
            //    return 1;
            //else
            //    return -1;
            return x.MonthlySpend - y.MonthlySpend;
        }
    }

    public class CustomerCityComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return string.Compare(x.City, y.City);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("igor", "adresa1", "Bridgetown", 1000);
            Customer c2 = new Customer("blagoj", "adresa3", "Speightstown", 100);
            Customer c3 = new Customer("dejan", "adresa5", "Toronto", 250);
            Customer c4 = new Customer("petar", "adresa2", "Edmonton", 356);
            Customer c5 = new Customer("dime", "adresa4", "Winnipeg", 1200);

            Customer[] customers = new Customer[] { c1, c2, c3, c4, c5 };
            Console.WriteLine(string.Join("\n", customers.AsEnumerable()));

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");

            Array.Sort(customers, new CustomerMonthlySpendComparer());
            Console.WriteLine(string.Join("\n", customers.AsEnumerable()));

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");

            Array.Sort(customers, new CustomerCityComparer());
            Console.WriteLine(string.Join("\n", customers.AsEnumerable()));

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");

            Array.Sort(customers);
            Console.WriteLine(string.Join("\n", customers.AsEnumerable()));

            Console.ReadLine();
        }
    }
}
