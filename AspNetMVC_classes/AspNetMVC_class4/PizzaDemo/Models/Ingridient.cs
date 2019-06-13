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

        public override bool Equals(object obj)
        {
            Ingridient ingre = obj as Ingridient;
            if (ingre == null)
                return false;
            if (this.ID == ingre.ID)
                return true;
            else
                return false;
        }
    }
}
