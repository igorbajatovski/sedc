using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class Ingridient
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<string> Allergens { get; set; }

        public Ingridient(int ID, string name, List<string> allergens)
        {
            this.ID = ID;
            this.Name = name;
            this.Allergens = allergens;
        }
    }
}
