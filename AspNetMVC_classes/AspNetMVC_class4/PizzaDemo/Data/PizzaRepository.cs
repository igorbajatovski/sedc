using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;

namespace PizzaDemo.Data
{
    public class PizzaRepository : IPizzaRepository
    {
        public Menu getMenu()
        {
            return Storage.RestoruantMenu;
        }

        public Pizza GetPizza(int id)
        {
            return Storage.Pizzas[id];
        }

        public void Save(Pizza pizza)
        {
            Storage.Pizzas.Add(pizza);
        }


    }
}
