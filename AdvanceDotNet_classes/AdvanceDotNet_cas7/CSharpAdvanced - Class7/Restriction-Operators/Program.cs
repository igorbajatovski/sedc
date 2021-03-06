﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFromXml;

namespace Restriction_Operators {
    class Program {
        static void Main(string[] args) {

            //load all the products, customers, orders
            List<Product> products = Product.GetAllProducts();
            List<Customer> customers = Customer.GetAllCustomers();
            List<Order> orders = Order.GetAllOrders();

            Action line = () => Console.WriteLine();

            //Linq 1: find all elements of an array less than 5. 
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, -12, -14 };
            var lessThenFive = numbers.Where(e => e < 5);
            Console.WriteLine(string.Join(",", lessThenFive));
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            //Linq 2: find all products that are out of stock, i.e. UnitsInStock == 0
            var soldOutProducts = products.Where(e => e.UnitsInStock == 0);
            Product.PrintProducts(soldOutProducts);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            //Linq 3: find all products that are in stock and cost more than 3.00 per unit. 
            var expensiveInStockProducts2 = products.Where(e => e.UnitsInStock > 0 && e.UnitPrice > 3.00);
            Product.PrintProducts(expensiveInStockProducts2);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            /*
             Linq 4: This sample uses where to find all customers in Berlin and then uses 
                     the resulting sequence to drill down into their orders.
            */
            //load all customers            

            //sql-like approach:
            var berlinCustomers = from c in customers
                                  where c.City == "Berlin"
                                  select c;
            Console.WriteLine("Customers from Berlin and their orders:");
            foreach (var cust in berlinCustomers)
            {
                Console.WriteLine("Customer {0}: {1}", cust.CustomerID, cust.CompanyName);
                var custOrders = from o in orders
                                 where o.CustomerID == cust.CustomerID
                                 select o;
                Order.PrintOrders(custOrders);
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");


            berlinCustomers = customers.Where(c => c.City == "Berlin").Select(c => c);
            Console.WriteLine("Customers from Berlin and their orders:");
            foreach (var cust in berlinCustomers)
            {
                Console.WriteLine("Customer {0}: {1}", cust.CustomerID, cust.CompanyName);
                var custOrders = orders.Where(o => o.CustomerID == cust.CustomerID);
                Order.PrintOrders(custOrders);
            }

            line();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            //Linq 5: This sample demonstrates an indexed Where clause that returns digits whose 
            // name is shorter than their position value. Print out those. 

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortDigits = digits.Where((digit, index) => digit.Length < index);
            Console.WriteLine(string.Join(",", shortDigits));

            //shortDigits = from num in digits where num.Length < num.Index select num;

            Console.ReadLine();
        }

    }
}
