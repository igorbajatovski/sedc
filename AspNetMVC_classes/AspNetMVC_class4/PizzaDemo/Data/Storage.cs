using PizzaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Data
{
    internal static class Storage
    {
        // List of ingridients
        public static List<Ingridient> Ingidients = new List<Ingridient>()
        {
            new Ingridient(1, "ham", new List<string>()),
            new Ingridient(2, "cheese", new List<string>() { "milk" }),
            new Ingridient(3, "mashrooms", new List<string>()),
            new Ingridient(4, "pepperoni", new List<string>())
        };

        // List of pizzas
        public static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza(1, "Capri", "The best capri pizza in tiown!",
                new List<Ingridient>()
                {
                    Ingidients[0],
                    Ingidients[1],
                    Ingidients[2]
                }, 160
            ),

            new Pizza(2, "Pepperoni", "The best pepperoni pizza in tiown!",
                new List<Ingridient>()
                {
                    Ingidients[3],
                    Ingidients[1],
                    Ingidients[2]
                }, 160
           )
        };

        // Restorant Menu
        public static Menu RestoruantMenu = new Menu("Pizza House", Pizzas);

        public static List<User> Users = new List<User>()
        {
            new User(1, "071/354-789", "Igor Bajatovski", "Tome Arsovski 49"),
            new User(2, "071/789-789", "Blagoj Ristovski", "Aerodrom 14"),
            new User(3, "078/321-123", "Aleksandar Makedonski", "Plostad Makedonija")
        };

        // List of pizza orders
        public static List<Order> Orders = new List<Order>();
        
    }
}
