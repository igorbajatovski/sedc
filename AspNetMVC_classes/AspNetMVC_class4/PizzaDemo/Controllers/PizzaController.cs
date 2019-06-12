﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDemo.Services;
using PizzaDemo.Data;
using PizzaDemo.ViewModels;

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
            if(!ModelState.IsValid)
            {
                return View(pizza);
            }

            this._pizzaService.CreatePizza(pizza);

            return RedirectToAction("Menu", controllerName: "Pizza");
        }
    }
}