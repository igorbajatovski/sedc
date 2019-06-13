using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;

namespace PizzaDemo.Data
{
    interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        List<User> GetAll();
        User GetById(int id);
        void Delete(User user);
    }
}
