﻿using PizzaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Services
{
    public interface IPizzaService
    {
        Menu getMenu();
    }
}
