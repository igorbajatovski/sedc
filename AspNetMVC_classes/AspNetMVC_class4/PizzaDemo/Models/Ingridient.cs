using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class Ingridient
    {
        public string Name { get; set; }

        public List<string> Allergens { get; set; }

        public Ingridient(string name, List<string> allergens)
        {
            this.Name = name;
            this.Allergens = allergens;
        }
    }
}
