using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1Class03_WebApp1.Models;

namespace WebApplication1Class03_WebApp1.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Details()
        {
            Person person = new Person() { FirstName = "Risto", LastName = "Pancevski" };
            return View(person);
        }
    }
}