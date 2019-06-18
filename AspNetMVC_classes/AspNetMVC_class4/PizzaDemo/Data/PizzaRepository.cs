using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;

namespace PizzaDemo.Data
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public void Create(Pizza entity)
        {
            Storage.Pizzas.Add(entity);
        }

        public void Delete(Pizza entity)
        {
            Storage.Pizzas.Remove(entity);
        }

        public List<Pizza> GetAll()
        {
            return Storage.Pizzas;
        }

        public Pizza GetById(int id)
        {
            return Storage.Pizzas.Where(e => e.ID == id).FirstOrDefault();
        }

        public void Update(Pizza entity)
        {
            var foundUser = Storage.Pizzas.Where(u => u.ID == entity.ID).ToArray();
            if (foundUser.Length == 1)
            {
                foundUser[0].Name = entity.Name;
                foundUser[0].Description = entity.Description;
                foundUser[0].Ingridients = entity.Ingridients;
                foundUser[0].Prize = entity.Prize;
            }
        }
    }
}
