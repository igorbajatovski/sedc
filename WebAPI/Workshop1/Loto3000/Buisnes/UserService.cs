using System;
using System.Collections.Generic;
using System.Text;
using DataModels;
using Models;
using Data;
using System.Linq;

namespace Buisnes
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return this._userRepository.GetAll().Select(u => new UserModel()
            {
                Id = u.Id,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Balance = u.Balance,
                Role = u.Role
            });
        }

        public void RegisterUser(UserModel userModel)
        {
            var userExists = this._userRepository.GetAll().Where(u => u.Username == userModel.Username).FirstOrDefault();
            if(userExists != null)
            {
                throw new Exception($"User \"{userModel.Username}\" is already registered");
            }

            User user = new User()
            {
                Username = userModel.Username,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Balance = 1000,
                Role = Role.User
            };

            this._userRepository.Insert(user);
        }
    }
}
