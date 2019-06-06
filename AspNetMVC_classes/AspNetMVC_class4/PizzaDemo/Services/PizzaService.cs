using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;
using PizzaDemo.Data;

namespace PizzaDemo.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            this._pizzaRepository = pizzaRepository;
        }

        public Menu getMenu()
        {
            return _pizzaRepository.getMenu();
        }
    }
}
