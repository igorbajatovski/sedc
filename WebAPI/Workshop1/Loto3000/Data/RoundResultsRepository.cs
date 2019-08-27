using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DataModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RoundResultsRepository : IRepository<RoundResults>
    {
        private readonly LotoDbContext _lotoDB;

        public RoundResultsRepository(DbContext lotoDB)
        {
            this._lotoDB = (LotoDbContext)lotoDB;
        }

        public void Delete(RoundResults entity)
        {
            _lotoDB.RoundResults.Remove(entity);
        }

        public IEnumerable<RoundResults> GetAll()
        {
            var db = _lotoDB.getNewLotoDbContext();
            return db.RoundResults.AsEnumerable();
        }

        public void Insert(RoundResults entity)
        {
            _lotoDB.RoundResults.Add(entity);
        }

        public int Save()
        {
            return _lotoDB.SaveChanges();
        }

        public void Update(RoundResults entity)
        {
            _lotoDB.RoundResults.Update(entity);
        }
    }
}
