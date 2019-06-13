using PizzaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Data
{
    public interface IPizzaRepository
    {
        Menu getMenu();
        void Save(Pizza pizza);
        Pizza GetPizza(int id);
    }
}
