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
            lock (_lotoDB)
                _lotoDB.RoundResults.Remove(entity);
        }

        public IEnumerable<RoundResults> GetAll()
        {
            lock (_lotoDB)
                return _lotoDB.RoundResults.AsEnumerable();
        }

        public void Insert(RoundResults entity)
        {
            lock (_lotoDB)
                _lotoDB.RoundResults.Add(entity);
        }

        public int Save()
        {
            lock (_lotoDB)
                return _lotoDB.SaveChanges();
        }

        public void Update(RoundResults entity)
        {
            lock (_lotoDB)
                _lotoDB.RoundResults.Update(entity);
        }
    }
}
