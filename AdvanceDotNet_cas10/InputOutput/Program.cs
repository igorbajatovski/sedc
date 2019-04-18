using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace InputOutput
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            /*
            string str = @"Nekoj
                                tekst so 
                                nekolku
                                linni.";
            string path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas10\InputOutput\turiGoTuka.txt";
            File.WriteAllText(path, str);

            string newText = "nov text";
            File.AppendAllText(path, newText, Encoding.ASCII);

            path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas10\InputOutput\turiGoTuka1.txt";
            string[] words = ("Ova recenica rascleneta vo zborovi").Split(' ');
            File.WriteAllLines(path, words);
            */
            /*
            string path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas10\InputOutput\turiGoTuka.txt";
            string content = File.ReadAllText(path, Encoding.ASCII);
            Console.WriteLine("Content: \n{0}", content);

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            string[] lines = File.ReadAllLines(path, Encoding.ASCII);
            int l = 0;
            foreach (var line in lines)
            {
                var wordCount = line.Trim().Split(' ').Count();
                Console.WriteLine("Line {0}: {1} | Length {2}, Words {3}", l++, line, line.Length, wordCount);
            }

            string path2 = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas10\InputOutput\turiGoTuka - Copy.txt";
            if (!File.Exists(path))
                File.Copy(path, path2);

            string path3 = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas10\InputOutput\New Folder\turiGoTuka.txt"; ;
            File.Move(path, path3);
            */

            List<Customer> customers = new List<Customer>()
            {
                new Customer() { ID = 1, Name = "Igor", City = "Skopje" },
                new Customer() { ID = 2, Name = "Martin", City = "Skopje" },
                new Customer() { ID = 3, Name = "Dejan", City = "Stip" }
            };


            string path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas10\InputOutput\Customers.csv";
            using (StreamWriter sw = new StreamWriter(path))
            {
                using (CsvWriter csv = new CsvWriter(sw))
                {
                    csv.WriteRecords(customers);
                }
            }

            IEnumerable<Customer> cust = null;
            using (StreamReader sr = new StreamReader(path))
            {
                using (CsvReader csv = new CsvReader(sr))
                {
                    cust = csv.GetRecords<Customer>();
                    foreach (var c in cust)
                    {
                        Console.WriteLine("{0}, {1}, {2}", c.ID, c.Name, c.City);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
