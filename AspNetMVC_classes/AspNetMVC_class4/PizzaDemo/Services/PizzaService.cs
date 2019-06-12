using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;
using PizzaDemo.Data;
using PizzaDemo.ViewModels;

namespace PizzaDemo.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            this._pizzaRepository = pizzaRepository;
        }

        public void CreatePizza(PizzaViewModel pizza)
        {
            var nextId = Storage.Pizzas.Last().ID + 1;
            var ingridients = new List<Ingridient>();

            foreach(var ingridient in pizza.SelectedIngridients)
            {
                ingridients.Add(Storage.Ingidients[ingridient-1]);
            }

            var pizzaModel = new Pizza(nextId, pizza.Name, pizza.Description, ingridients, pizza.BasePrise);
            _pizzaRepository.Save(pizzaModel);
        }

        public Menu getMenu()
        {
            return _pizzaRepository.getMenu();
        }
    }
}
