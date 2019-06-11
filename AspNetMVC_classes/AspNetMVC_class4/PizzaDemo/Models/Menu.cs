﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class Menu
    {
        public string RestorantName { get; set; }

        public List<PizzaViewModel> Pizzas;

        public List<SizeEnum> Sizes { get; set; }

        public Menu(string restoranName, List<PizzaViewModel> pizzas)
        {
            this.RestorantName = restoranName;
            this.Pizzas = pizzas;
            this.Sizes = new List<SizeEnum>() { SizeEnum.Small, SizeEnum.Medium, SizeEnum.Large };
        }
    }
}
