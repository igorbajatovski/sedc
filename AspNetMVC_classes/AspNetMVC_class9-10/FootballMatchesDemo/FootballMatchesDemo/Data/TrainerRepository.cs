using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchesDemo.Models;

namespace FootballMatchesDemo.Data
{
    public class TrainerRepository : IRepository<Trainer>
    {
        private readonly FootballMatchesDBContext _dbConnection = null;

        public TrainerRepository(FootballMatchesDBContext dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public ICollection<Trainer> GetAll()
        {
            return this._dbConnection.Trainers.ToList();
        }

        public void Save(Trainer entity)
        {
            this._dbConnection.Trainers.Add(entity);
            this._dbConnection.SaveChanges();
        }
    }
}
