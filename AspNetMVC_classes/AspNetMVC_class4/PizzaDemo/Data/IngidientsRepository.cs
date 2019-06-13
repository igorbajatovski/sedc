using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;

namespace PizzaDemo.Data
{
    public class IngidientsRepository : IIngidientsRepository
    {
        public void Create(Ingridient user)
        {
            Storage.Ingidients.Add(user);
        }

        public void Delete(Ingridient ingre)
        {
            Storage.Ingidients.Remove(ingre);
        }

        public List<Ingridient> GetAll()
        {
            return Storage.Ingidients;
        }

        public Ingridient GetById(int id)
        {
            return Storage.Ingidients.FirstOrDefault(i => i.ID == id);
        }

        public void Update(Ingridient ingre)
        {
            var foundIngridient = Storage.Ingidients.Where(i => i.ID == ingre.ID).ToArray();
            if (foundIngridient.Length == 1)
            {
                foundIngridient[0].Allergens = ingre.Allergens;
                foundIngridient[0].Name = ingre.Name;
            }
        }
    }
}
