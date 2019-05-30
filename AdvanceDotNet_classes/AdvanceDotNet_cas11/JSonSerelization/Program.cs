using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

namespace JSonSerelization
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Employee
    {
        [JsonProperty(PropertyName = "Employe ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "FullName")]
        public string Name { get; set; }

        [JsonProperty]
        public char Gender { get; set; }

        [JsonProperty]
        public string WorkPhone { get; set; }

        [JsonProperty]
        private string Address { get; set; }

        [JsonProperty]
        public List<string> Skills { get; set; }

        public void SetPrivates(string address)
        {
            this.Address = address;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Gender: {2}, WorkPhone: {3}, Address: {4}, Skills: {5}", ID, Name, Gender, WorkPhone, Address,
                string.Join(", ", Skills));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee() { ID = 1, Name = "Igor Bajatovski", Gender = 'M', WorkPhone = "071/231-789", Skills = new List<string> { "C#", "SQL Server" } };
            e.SetPrivates("Tome Arsovski 49 1/41");
            Employee e1 = new Employee() { ID = 2, Name = "Dejan Jovanov", Gender = 'M', WorkPhone = "078/456-222", Skills = new List<string> { "C#", "SQL Server" } };
            e1.SetPrivates("Partizanski Odredi 49 1/41");
            List<Employee> employees = new List<Employee>() { e, e1 };

            string path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas11\employesJson.json";
            string jsonContent = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText(path, jsonContent);

            var empls = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(path));
            Console.WriteLine("Employes: \n" + string.Join("\n", empls));
        }
    }
}
