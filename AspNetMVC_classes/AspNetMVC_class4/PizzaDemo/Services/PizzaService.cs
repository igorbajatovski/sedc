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
        private readonly IRepository<Ingridient> _ingridientRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository, IRepository<Ingridient> ingridientRepository)
        {
            this._pizzaRepository = pizzaRepository;
            this._ingridientRepository = ingridientRepository;
        }

        public void CreatePizza(PizzaViewModel pizza)
        {
            Pizza lastPizza = Storage.Pizzas.Last();
            int nextId = 1;
            if (lastPizza != null)
                nextId = Storage.Pizzas.Last().ID + 1;
            var ingridients = new List<Ingridient>();

            foreach(var ingridient in pizza.SelectedIngridients)
            {
                ingridients.Add(this._ingridientRepository.GetById(ingridient));
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

        public void EditPizza(PizzaViewModel pizza)
        {
            _pizzaRepository.Update(pizza.ToModel());
        }

        public void DeletePizza(Pizza pizza)
        {
            _pizzaRepository.Delete(pizza);
        }

        public List<Pizza> GetAllPizzas()
        {
            return _pizzaRepository.GetAll();
        }

        public int MaxPizzasToOrder()
        {
            return 5;
        }
    }
}
