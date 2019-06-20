using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;

namespace PizzaDemo.Data
{
    interface IIngridientsRepository
    {
        void Create(Ingridient user);
        void Update(Ingridient user);
        List<Ingridient> GetAll();
        Ingridient GetById(int id);
        void Delete(Ingridient user);
    }
}
