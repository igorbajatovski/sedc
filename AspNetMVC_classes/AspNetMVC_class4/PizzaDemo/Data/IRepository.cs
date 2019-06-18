using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;

namespace PizzaDemo.Data
{
    public interface IRepository<T> where T : IEntity
    {
        void Create(T entity);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Delete(T entity);
    }
}
