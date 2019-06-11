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
            new Pizza(1, "Capri", "The best capri pizza in tiown!",
                new List<Ingridient>()
                {
                    new Ingridient(1, "ham", new List<string>()),
                    new Ingridient(2, "cheese", new List<string>() { "milk" }),
                    new Ingridient(3, "mashrooms", new List<string>())
                }, 160
            ),

            new Pizza(2, "Pepperoni", "The best pepperoni pizza in tiown!",
                new List<Ingridient>()
                {
                    new Ingridient(1, "pepperoni", new List<string>()),
                    new Ingridient(2, "cheese", new List<string>() { "milk" }),
                    new Ingridient(3, "mashrooms", new List<string>())
                }, 160
           )
        };

        public static Menu RestoruantMenu = new Menu("Pizza House", Pizzas);

        public static List<Ingridient> Ingidients = new List<Ingridient>()
        {
            new Ingridient(1, "ham", new List<string>()),
            new Ingridient(2, "cheese", new List<string>() { "milk" }),
            new Ingridient(3, "mashrooms", new List<string>()),
            new Ingridient(4, "pepperoni", new List<string>())
        };

    }
}
