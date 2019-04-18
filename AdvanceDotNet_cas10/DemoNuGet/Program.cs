using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace DemoNuGet_NewtonSoftJson
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
        {/*
            JObject o = new JObject()
            {
                new JProperty("Name", "Igor"),
                new JProperty("Age", 35),
                new JProperty("City", "Skopje")
            };

            Console.WriteLine(o.ToString());
            string path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas10\DemoNuGet\MyFirstJson.json";
            //File.WriteAllText(path, o.ToString());

            JObject jObject;
            jObject = JObject.Parse(File.ReadAllText(path));
            Console.WriteLine(jObject);

            List<string> skills = new List<string>()
            {
                "C#", "Sql Server"
            };

            o["Skills"] = JToken.FromObject(skills);

            Console.WriteLine(o.ToString());

            string[] firmi = new string[] { "Seavus", "SEDC" };
            o.Add("Firms", JToken.FromObject(firmi));
            Console.WriteLine(o.ToString());
            */
            List<JObject> jCustomers = new List<JObject>();
            Customer c1 = new Customer() { ID = 1, Name = "Igor", City = "Skopje" };
            Customer c2 = new Customer() { ID = 2, Name = "Martin", City = "Skopje" };
            Customer c3 = new Customer() { ID = 3, Name = "Dejan", City = "Stip" };
            JObject jC1 = JObject.FromObject(c1);
            JObject jC2 = JObject.FromObject(c2);
            JObject jC3 = JObject.FromObject(c3);
            jCustomers.Add(jC1);
            jCustomers.Add(jC2);
            jCustomers.Add(jC3);

            Console.WriteLine(string.Join("\n", jCustomers));

            string json = JsonConvert.SerializeObject(jCustomers, Formatting.Indented);
            Console.WriteLine("jCustomers: " + json);
        }
    }
}
