using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchesDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballMatchesDemo.Data
{
    public class TeamsRepository : IRepository<Team>
    {
        private readonly FootballMatchesDBContext _dbConnection = null;

        public TeamsRepository(FootballMatchesDBContext dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public ICollection<Team> GetAll()
        {
            this._dbConnection.Teams.Load();
            this._dbConnection.Trainers.Load();
            this._dbConnection.Players.Load();
            return this._dbConnection.Teams.ToList();
        }

        public DbContext GetDbConnection()
        {
            return this._dbConnection;
        }

        public void Save(Team entity)
        {
            this._dbConnection.Teams.Add(entity);
            this._dbConnection.SaveChanges();
        }
    }
}
