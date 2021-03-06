﻿using PizzaDemo.Models;
using PizzaDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Services
{
    public interface IPizzaService
    {
        Menu getMenu();
        void CreatePizza(PizzaViewModel pizza);
        Pizza GetPizza(int id);
        void EditPizza(PizzaViewModel pizza);
        void DeletePizza(Pizza pizza);
        List<Pizza> GetAllPizzas();
        int MaxPizzasToOrder();
    }
}
