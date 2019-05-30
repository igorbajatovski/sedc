using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int MonthlySpend { get; set; }

        public Customer() { }
        public Customer(string name, string address, string city, int monthlySpend)
        {
            this.Name = name; this.Address = address; this.City = city; this.MonthlySpend = monthlySpend;
        }
        public void PrintCustomer()
        {
            Console.WriteLine($"Customer: {Name}, {Address}, {City}, {MonthlySpend}");
        }
        public int CompareTo(Customer c)
        {
            return this.MonthlySpend.CompareTo(c.MonthlySpend);
        }

        public bool Equals(Customer other)
        {
            if (this.Name == other.Name && this.Address == other.Address && this.City == other.City)
                return true;
            return false;
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            if (c1.Name == c2.Name && c1.Address == c2.Address && c1.City == c2.City)
                return true;
            return false;
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            if (c1.Name != c2.Name || c1.Address != c2.Address || c1.City != c2.City)
                return true;
            return false;
        }
    }

    public class CustomerMonthlySpendComparer : IComparer<Customer>
    {
        public int Compare(Customer c1, Customer c2)
        {
            return c1.MonthlySpend - c2.MonthlySpend;
        }


    }
    public class CustomerCityComparer : IComparer<Customer>
    {
        public int Compare(Customer c1, Customer c2)
        {
            return string.Compare(c1.City, c2.City);
        }
    }
}
