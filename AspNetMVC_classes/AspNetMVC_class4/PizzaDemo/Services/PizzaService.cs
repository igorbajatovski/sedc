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
        private readonly IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
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
            _pizzaRepository.Create(pizzaModel);
        }

        public Menu getMenu()
        {
            return Storage.RestoruantMenu;
        }

        public Pizza GetPizza(int id)
        {
            return _pizzaRepository.GetById(id);
        }
    }
}
