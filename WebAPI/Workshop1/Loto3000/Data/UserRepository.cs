using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DataModels;
using System.Linq;

namespace Data
{
    public class UserRepository : IRepository<User>
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("LotoDb");
        }

        public void Delete(User entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.Users.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                return db.Users.ToList();
            }
        }

        public void Insert(User entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.Users.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.Users.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
