using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFromXml;

namespace Partitioning_Operators {
    class Program {
        static void Main(string[] args) {

            //load all the products, customers, orders
            List<Product> products = Product.GetAllProducts();
            List<Customer> customers = Customer.GetAllCustomers();
            List<Order> orders = Order.GetAllOrders();

            //Linq 20: get only the first 3 elements of the array.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstThree = numbers.Take(3);
            //Console.WriteLine(string.Join(",", firstThree));

            //Linq 21: get the first 3 orders from customers in London. 
            IEnumerable<Customer> first3LondonCustomers = customers.Where(c => c.City == "London").Take(3);
            //Customer.PrintCustomers(first3LondonCustomers);

            //sql-like approach 
            int i = 0;
            first3LondonCustomers = from cus in customers where cus.City == "London" && i++ < 3 select cus;
            //Customer.PrintCustomers(first3LondonCustomers);

            //Linq 22: get all but the first 4 elements of the array. Skip() 
            var skip4 = numbers.Skip(4);
           // Console.WriteLine(string.Join(",", skip4));

            //Linq 23: get all but the first 1 order from customers in 'Rio de Janeiro'
            var allButFirstOneRio = customers.Where(c => c.City == "Rio de Janeiro").Skip(1);
           // Customer.PrintCustomers(allButFirstOneRio);

            //Linq 24: TakeWhile to return elements starting from the beginning of the array 
            //until a number is hit that is not less than 6. 
            numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var takeWhile6 = numbers.TakeWhile(n => n < 6);
            Console.WriteLine(string.Join(",", takeWhile6));

            //Linq 25: TakeWhile to return elements starting from the beginning of the array until 
            // a number is hit that is less than its position in the array.
            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);
            Console.WriteLine("First numbers not less than their position: {0}", string.Join(" ", firstSmallNumbers));

            //Linq 26: SkipWhile to get the elements of the array starting from the first 
            //element divisible by 3.
            //{  5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
            var allNotDivisibleBy3 = numbers.SkipWhile(n => n % 3 != 0);
            Console.WriteLine("All numbers not divisible by 3: {0}", string.Join(" ", allNotDivisibleBy3));

            //Linq 27: SkipWhile to get the elements of the array starting from the first element less 
            //than its position.
            var laterNumbers = numbers.SkipWhile((n, index) => n >= index);
            Console.WriteLine("Skip first numbers greater then their position: {0}", string.Join(" ", laterNumbers));

        }
    }
}
