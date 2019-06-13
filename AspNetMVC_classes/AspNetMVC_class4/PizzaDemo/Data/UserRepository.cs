using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.Models;

namespace PizzaDemo.Data
{
    public class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            Storage.Users.Add(user);
        }

        public void Delete(User user)
        {
            Storage.Users.Remove(user);
        }

        public List<User> GetAll()
        {
            return Storage.Users;
        }

        public User GetById(int id)
        {
            return Storage.Users[id];
        }

        public void Update(User user)
        {
            var foundUser = Storage.Users.Where(u => u.ID == user.ID).ToArray();
            if (foundUser.Length == 1)
            {
                foundUser[0].FullName = user.FullName;
                foundUser[0].Address = user.Address;
                foundUser[0].PhoneNumber = user.PhoneNumber;
            }
        }
    }
}
