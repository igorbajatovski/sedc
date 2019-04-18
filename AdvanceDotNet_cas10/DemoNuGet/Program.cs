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
    class Program
    {
        static void Main(string[] args)
        {
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


        }
    }
}
