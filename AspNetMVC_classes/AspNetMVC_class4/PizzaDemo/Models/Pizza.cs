using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class Pizza
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        private readonly int _prize;

        public List<Ingridient> Ingridients = null;

        public Pizza(int ID, string name, string description, List<Ingridient> ingrediants, int prize)
        {
            this.ID = ID;
            this.Name = name;
            this.Description = description;
            this.Ingridients = ingrediants;
            this._prize = prize;
        }

        public int getPrize(SizeEnum size)
        {
            if (size == SizeEnum.Small)
                return _prize;
            else if (size == SizeEnum.Medium)
                return (int) Math.Ceiling(_prize * 1.2);
            else
                return (int) Math.Ceiling(_prize * 1.4);
        }
    }
}
