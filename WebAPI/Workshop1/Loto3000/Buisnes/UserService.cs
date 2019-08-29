using System;
using System.Collections.Generic;
using DataModels;
using Models;
using Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Buisnes
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly JwtSettings _jwtSettings;

        public UserService(IRepository<User> userRepository, IOptions<JwtSettings> jwtSettings)
        {
            this._userRepository = userRepository;
            this._jwtSettings = jwtSettings.Value;
        }

        public UserModel Authenticate(UserModel user)
        {
            // Check if user exists
            var md5 = new MD5CryptoServiceProvider();
            var passwordBytes = Encoding.ASCII.GetBytes(user.Password);
            var hashBytes = md5.ComputeHash(passwordBytes);
            var hash = Encoding.ASCII.GetString(hashBytes);

            var userExists = _userRepository.GetAll()
                .FirstOrDefault(x => x.Password == hash && x.Username == user.Username);

            if (userExists == null)
                throw new Exception("Username or password is wrong.");
            // End of Check if user exists

            //Create token
            var keyBytes = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var jwtTokenHandler = new JwtSecurityTokenHandler();


            var descriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                })
            };

            var token = jwtTokenHandler.CreateToken(descriptor);
            var tokenString = jwtTokenHandler.WriteToken(token);

            // Return user with token
            var userAuth = new UserModel()
            {   
                Username = userExists.Username,
                FirstName = userExists.FirstName,
                LastName = userExists.LastName,
                Token = tokenString
            };
            return userAuth;
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

        public void RegisterUser(UserModel user)
        {
            ValidateUser(user);

            var md5 = new MD5CryptoServiceProvider();
            var passwordBytes = Encoding.ASCII.GetBytes(user.Password);
            var hashBytes = md5.ComputeHash(passwordBytes);
            var hash = Encoding.ASCII.GetString(hashBytes);

            User registeredUser = new User()
            {
                Username = user.Username,
                Password = hash,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Balance = 1000,
                Role = Role.User
            };

            this._userRepository.Insert(registeredUser);
            this._userRepository.Save();
        }

        private void ValidateUser(UserModel user)
        {
            if(string.IsNullOrEmpty(user.Username))
                throw new Exception("Username is required");

            if (string.IsNullOrEmpty(user.FirstName))
                throw new Exception("First name is required");

            if (string.IsNullOrEmpty(user.LastName))
                throw new Exception("Last name is required");

            if (string.IsNullOrEmpty(user.Password))
                throw new Exception("Password is required");

            if (user.Username.Length > 20)
                throw new Exception("Username of user is longer then 20 characters");

            if (user.Password.Length > 20)
                throw new Exception("Password of user is longer then 20 characters");

            if (user.FirstName.Length > 50)
                throw new Exception("Username's first name is longer then 50 characters");

            if (user.FirstName.Length > 50)
                throw new Exception("Username's last name is longer then 50 characters");

            var userExists = this._userRepository.GetAll().Where(u => u.Username == user.Username).FirstOrDefault();
            if (userExists != null)
            {
                throw new Exception($"User \"{user.Username}\" is already registered");
            }
        }
    }
}
