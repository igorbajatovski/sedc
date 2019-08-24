using System;
using System.Collections.Generic;
using DataModels;
using Models;
using Data;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            ValidateUser(userModel);

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

        public void ValidateUser(UserModel user)
        {   
            if (user.Username.Length > 20)
                throw new Exception("Username of user is longer then 20 characters");

            if (user.FirstName.Length > 50)
                throw new Exception("Username's first name is longer then 50 characters");

            if (user.FirstName.Length > 50)
                throw new Exception("Username's last name is longer then 50 characters");

            if (user.Role != Role.Admin && user.Role != Role.User)
                throw new Exception("Username's role is incorrect");

            var userExists = this._userRepository.GetAll().Where(u => u.Username == user.Username).FirstOrDefault();
            if (userExists != null)
            {
                throw new Exception($"User \"{user.Username}\" is already registered");
            }
        }
    }
}
