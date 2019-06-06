using PizzaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Data
{
    internal static class Storage
    {
        public static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza("Capri", "The best capri pizza in tiown!",
                new List<Ingridient>()
                {
                    new Ingridient("ham", new List<string>()),
                    new Ingridient("cheese", new List<string>() { "milk" }),
                    new Ingridient("mashrooms", new List<string>())
                }, 160
            ),

            new Pizza("Pepperoni", "The best pepperoni pizza in tiown!",
                new List<Ingridient>()
                {
                    new Ingridient("pepperoni", new List<string>()),
                    new Ingridient("cheese", new List<string>() { "milk" }),
                    new Ingridient("mashrooms", new List<string>())
                }, 160
           )
        };

        public static Menu RestoruantMenu = new Menu("Pizza House", Pizzas);

    }
}
