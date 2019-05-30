using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld_MVC.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Hello()
        {
            return View();
        }
    }
}