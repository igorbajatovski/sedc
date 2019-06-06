using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDemo.Services;
using PizzaDemo.Data;

namespace PizzaDemo.Controllers
{
    //[Route("pizzahouse")]
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this._pizzaService = pizzaService;
        }

        //[Route("Menu")]
        public IActionResult Menu()
        {
            var menu = _pizzaService.getMenu();
            return View(menu);
        }
    }
}