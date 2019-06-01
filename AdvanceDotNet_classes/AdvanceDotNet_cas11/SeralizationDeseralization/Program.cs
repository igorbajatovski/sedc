using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace SeralizationDeseralization
{
    //[Serializable]
    public class Employee
    {   
        public int ID { get; set; }
        [XmlElement(ElementName = "FullName")]
        public string Name { get; set; }
        [XmlIgnore]
        public char Gender { get; set; }
        public string WorkPhone { get; set; }
        private string Address { get; set; }
        [XmlArray("Technologies")]
        [XmlArrayItem("Language")]
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
            //Console.WriteLine("Seralization...");
            Employee e = new Employee() { ID = 1, Name = "Igor Bajatovski", Gender = 'M', WorkPhone = "071/231-789", Skills = new List<string> { "C#", "SQL Server" } };
            e.SetPrivates("Tome Arsovski 49 1/41");

            //IFormatter formatter = new BinaryFormatter();
            //string path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas11\BinarySeralization.bin";

            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, e);
            //}

            //Console.WriteLine("Deseralization...");

            //Employee temp;
            //using (FileStream fs = new FileStream(path, FileMode.Open))
            //{
            //    temp = (Employee)formatter.Deserialize(fs);
            //}

            //Console.WriteLine(temp);


            //Console.WriteLine("+++++++++ List seralization and deseralization +++++++++++++++++++");
            Employee e1 = new Employee() { ID = 2, Name = "Dejan Jovanov", Gender = 'M', WorkPhone = "078/456-222", Skills = new List<string> { "C#", "SQL Server" } };
            e1.SetPrivates("Partizanski Odredi 49 1/41");
            List<Employee> employees = new List<Employee>() { e, e1 };

            //path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas11\ListBinarySeralization.bin";
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, employees);
            //}

            //List<Employee> emps;
            //using (FileStream fs = new FileStream(path, FileMode.Open))
            //{
            //    emps = (List<Employee>) formatter.Deserialize(fs);
            //}

            //Console.WriteLine("Employes: \n" + string.Join("\n", emps));

            Console.WriteLine("+++++++++++++++++ XML seralization and deseralization +++++++++++++++++++");
            XmlSerializer xmlSer = new XmlSerializer(typeof(Employee));
            string path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas11\XMLSeralization.xml";
            using (StreamWriter sw = new StreamWriter(path))
            {
                xmlSer.Serialize(sw, e);
            }

            Employee tempEmpl;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                tempEmpl = (Employee)xmlSer.Deserialize(fs);
            }

            Console.WriteLine(tempEmpl);

            Console.WriteLine("+++++++++++++++++ XML list seralization and deseralization +++++++++++++++++++");
            xmlSer = new XmlSerializer(typeof(List<Employee>));
            path = @"C:\Users\igor.bajatovski\Documents\IBA\repo\AdvanceDotNet_cas11\ListXMLSeralization.xml";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSer.Serialize(fs, employees);
            }

            List<Employee> emps1;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                emps1 = (List<Employee>)xmlSer.Deserialize(fs);
            }

            Console.WriteLine("Employes: \n" + string.Join("\n", emps1));
        }
    }
}
