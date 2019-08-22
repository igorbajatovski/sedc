using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DataModels;
using System.Linq;

namespace Data
{
    public class RoundResultsRepository : IRepository<RoundResults>
    {
        private readonly string _connectionString;

        public RoundResultsRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("LotoDb");
        }

        public void Delete(RoundResults entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.RoundResults.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<RoundResults> GetAll()
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                return db.RoundResults.ToList();
            }
        }

        public void Insert(RoundResults entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.RoundResults.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(RoundResults entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.RoundResults.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
