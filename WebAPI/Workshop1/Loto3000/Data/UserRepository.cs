using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DataModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UserRepository : IRepository<User>
    {
        private readonly LotoDbContext _lotoDB;

        public UserRepository(DbContext lotoDB)
        {
            this._lotoDB = (LotoDbContext)lotoDB;
        }

        public void Delete(User entity)
        {
            _lotoDB.Users.Remove(entity);
        }

        public IEnumerable<User> GetAll()
        {
            var db = _lotoDB.getNewLotoDbContext();
            return db.Users.ToList();
        }

        public void Insert(User entity)
        {
            _lotoDB.Users.Add(entity);
        }

        public int Save()
        {
            return _lotoDB.SaveChanges();
        }

        public void Update(User entity)
        {
            _lotoDB.Users.Update(entity);
        }
    }
}
