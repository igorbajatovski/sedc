using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Data;
using PizzaDemo.Models;

namespace PizzaDemo.Data
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        public void Create(T entity)
        {
            var entityList = GetAll();
            entityList.Add(entity);
        }

        public void Delete(T entity)
        {
            var entityList = GetAll();
            entityList.Remove(entity);
        }

        public List<T> GetAll()
        {
            Type entityType = typeof(T);
            Type storageType = typeof(Storage);
            List<T> entityList = null;

            foreach (var prop in storageType.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                if (prop.Name == $"{entityType.Name}s")
                {
                    entityList = prop.GetValue(null) as List<T>;
                    break;
                }
            }

            return entityList;
        }

        public T GetById(int id)
        {
            var entityList = GetAll();
            return entityList.Where(e => e.ID == id).FirstOrDefault();
        }

        public void Update(T entity)
        {
            var entityList = GetAll();
            if(entity.ID <= entityList.Count - 1)
                entityList[entity.ID] = entity;
        }
    }
}
