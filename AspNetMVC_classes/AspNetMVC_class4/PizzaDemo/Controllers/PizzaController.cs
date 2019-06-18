using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDemo.Services;
using PizzaDemo.Data;
using PizzaDemo.ViewModels;
using PizzaDemo.Models;

namespace PizzaDemo.Controllers
{

    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this._pizzaService = pizzaService;
        }

        [HttpGet]
        public IActionResult Menu()
        {
            var menu = _pizzaService.getMenu();
            return View(menu);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PizzaViewModel pizzaViewModel = new PizzaViewModel();
            return View(pizzaViewModel);
        }

        [HttpPost]
        public IActionResult Create(PizzaViewModel pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            this._pizzaService.CreatePizza(pizza);

            return RedirectToAction("Menu", controllerName: "Pizza");
        }

        [HttpGet("/[Controller]/[Action]/{id}")]
        public IActionResult Details(int id)
        {
            Pizza pizza = _pizzaService.GetPizza(id);
            if (pizza != null)
                return View(pizza);
            else
                return LocalRedirect("/Pizza/Menu");
        }

        [HttpGet("/[Controller]/[Action]/{id}")]
        public IActionResult Edit(int id)
        {
            Pizza pizza = _pizzaService.GetPizza(id);

            if (pizza != null)
                return View(pizza.ToViewModel());
            else
                return LocalRedirect("/Pizza/Menu");
        }

        [HttpPost]
        public IActionResult Edit(PizzaViewModel pizzaViewModel)
        {
            if (!ModelState.IsValid)
                return View(pizzaViewModel);

            _pizzaService.EditPizza(pizzaViewModel);
            return LocalRedirect("/Pizza/Menu");
        }

        [HttpGet("/[Controller]/[Action]/{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = _pizzaService.GetPizza(id);
            if (pizza != null)
                _pizzaService.DeletePizza(pizza);

            return LocalRedirect("/Pizza/Menu");
        }
    }
}