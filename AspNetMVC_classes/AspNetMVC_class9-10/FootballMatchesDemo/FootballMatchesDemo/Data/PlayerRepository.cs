using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchesDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballMatchesDemo.Data
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly FootballMatchesDBContext _dbConnection = null;

        public PlayerRepository(FootballMatchesDBContext dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public ICollection<Player> GetAll()
        {
            return this._dbConnection.Players.ToList();
        }

        public DbContext GetDbConnection()
        {
            return this._dbConnection;
        }

        public void Save(Player entity)
        {
            this._dbConnection.Players.Add(entity);
            this._dbConnection.SaveChanges();
        }
    }
}
