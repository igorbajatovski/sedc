using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class Pizza
    {
        public string Name { get; set; }

        public string Description { get; set; }

        private const int _defaultPrize = 150;

        public List<Ingridient> Ingridients = null;

        public Pizza(string name, List<Ingridient> ingrediants)
        {
            this.Name = name;
            this.Ingridients = ingrediants;
        }

        public int getPrize(SizeEnum size)
        {
            if (size == SizeEnum.Small)
                return _defaultPrize;
            else if (size == SizeEnum.Medium)
                return (int) Math.Ceiling(_defaultPrize * 1.2);
            else
                return (int) Math.Ceiling(_defaultPrize * 1.4);
        }
    }
}
