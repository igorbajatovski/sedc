using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchesDemo.Models;

namespace FootballMatchesDemo.Data
{
    public class PlayerRepositorycs : IRepository<Player>
    {
        private readonly FootballMatchesDBContext _dbConnection = null;

        public PlayerRepositorycs(FootballMatchesDBContext dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public ICollection<Player> GetAll()
        {
            return this._dbConnection.Players.ToList();
        }

        public void Save(Player entity)
        {
            this._dbConnection.Players.Add(entity);
            this._dbConnection.SaveChanges();
        }
    }
}
