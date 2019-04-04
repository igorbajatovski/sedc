using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        public class Customer
        {   
            public string ID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"[{ID}, {Name}]";
            }
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public Employee(int id, string name)
            {
                this.ID = id;
                this.Name = name;
            }

            public override string ToString()
            {
                return $"[{ID}, {Name}]";
            }
        }

        public static List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }

        public static void Print<T>(IEnumerable<T> list)
        {
            foreach(var elem in list)
                Console.Write(elem + " ");
            Console.WriteLine();
        }

        public static void PrintCollections<T>(IEnumerable<T> list)
        {
            Type typeOf = typeof(T);
            if( !(typeOf.IsPrimitive || typeOf.IsValueType || typeOf == typeof(string) ) )
            {
                Console.WriteLine("-----------------------------------------------------------");
                
                // Print name of properties
                var props = typeof(T).GetProperties();
                foreach (var prop in props)
                    Console.Write($"{prop.Name}\t");
                Console.WriteLine();

                // Print values of properties
                foreach(var item in list)
                {
                    foreach(var prop in props)
                        Console.Write($"{prop.GetValue(item)}\t");
                    Console.WriteLine();
                }
            }
            else // Primitive data types
            {
                Console.WriteLine("-----------------------------------------------------------");
                foreach (var item in list)
                    Console.Write($"{item}\t");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            List<int> ints = BuildList(1, 2, 3);
            Print(ints);
            PrintCollections(ints);
            Console.WriteLine();

            List<string> strings = BuildList("igor", "blagoj", "darko", "petar");
            Print(strings);
            PrintCollections(strings);
            Console.WriteLine();

            List<Customer> customers = BuildList(
                new Customer() { ID = "1", Name = "Igor" },
                new Customer() { ID = "2", Name = "Blagoj" },
                new Customer() { ID = "3", Name = "Darko" });
            Print(customers);
            PrintCollections(customers);
            Console.WriteLine();

            Employee e1 = new Employee(1, "Igor");
            Employee e2 = new Employee(2, "Blagoj");
            Employee e3 = new Employee(3, "Petar");
            Dictionary<int, Employee> dic = new Dictionary<int, Employee>(){ { 0, e1 }, { 1, e2 }, { 2, e3 } };
            Print(dic);
            PrintCollections(dic);
            Console.WriteLine();

            Stack<int> stack = new Stack<int>(new int[] { 1,2,3,4 });
            Print(stack);
            PrintCollections(stack);
            Console.WriteLine();

            Console.ReadLine();
        }


    }
}
