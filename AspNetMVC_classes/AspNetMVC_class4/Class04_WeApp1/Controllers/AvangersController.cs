using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Class04_WeApp1.Controllers
{
    public class AvangersController : Controller
    {
        [Route("getAllAvangers")]
        public IActionResult Index()
        {
            var avanger = new { Name = "Thor" };
            return View(avanger);
        }

        [Route("avanger/{id?}")]
        public IActionResult Index(int? id)
        {
            var avengers = new System.Collections.ArrayList()
            {
                new { Name = "Thor" },
                new { Name = "Black Widow" },
                new { Name = "Iron Man" },
                new { Name = "Capetan America" }
            };

            if(id != null)
            {
                var a = avengers[id.Value];
                return View(a);
            }

            return View(new { Name = "No avanger found" });
        }

    }
}
