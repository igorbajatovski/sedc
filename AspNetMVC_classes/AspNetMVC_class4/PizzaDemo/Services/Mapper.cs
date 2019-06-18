using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;
using PizzaDemo.ViewModels;
using PizzaDemo.Data;

namespace PizzaDemo.Services
{
    public static class Mapper
    {
        public static Pizza ToModel(this PizzaViewModel pizzaViewModel)
        {
            List<Ingridient> ingridient = new List<Ingridient>();
            foreach (var ingre in pizzaViewModel.SelectedIngridients)
            {
                var _ingre = Storage.Ingidients.Where(i => i.ID == ingre).FirstOrDefault();
                if (_ingre != null)
                    ingridient.Add(_ingre);
            }

            Pizza _pizza = new Pizza(pizzaViewModel.ID, pizzaViewModel.Name, pizzaViewModel.Description, ingridient, pizzaViewModel.BasePrise);

            return _pizza;
        }

        public static PizzaViewModel ToViewModel(this Pizza pizza)
        {
            List<int> selectedIngredients = new List<int>();
            foreach (var ingre in pizza.Ingridients)
            {
                selectedIngredients.Add(ingre.ID);
            }

            PizzaViewModel pizzaViewModel = new PizzaViewModel(pizza.Name, pizza.Description, pizza.Prize, selectedIngredients);

            return pizzaViewModel;
        }
    }
}
