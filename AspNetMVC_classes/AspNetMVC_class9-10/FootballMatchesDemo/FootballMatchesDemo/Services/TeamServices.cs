using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchesDemo.Data;
using FootballMatchesDemo.Models;
using FootballMatchesDemo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FootballMatchesDemo.Services
{
    public class TeamServices : ITeamServices
    {
        private readonly IRepository<Team> _teamRepository = null;
        private readonly IRepository<Trainer> _trainerRepository = null;
        private readonly IRepository<Player> _playerRepository = null;

        public TeamServices(IRepository<Team> teamRepository,
                            IRepository<Trainer> trainerRepository,
                            IRepository<Player> playerRepository)
        {
            this._teamRepository = teamRepository;
            this._trainerRepository = trainerRepository;
            this._playerRepository = playerRepository;
        }

        public ICollection<Team> GetAllTeams()
        {
            return this._teamRepository.GetAll();
        }

        public TeamView AddPlayer(TeamView team)
        {
            int count = team.Players.Count;
            if (count == 0)
            {
                team.Players.Add(new PlayerView() { ID = 1, FirstName = team.Player.FirstName, LastName = team.Player.LastName });
            }
            else
            {
                team.Players.Add(new PlayerView() { ID = count + 1, FirstName = team.Player.FirstName, LastName = team.Player.LastName });
            }

            return team;
        }

        public TeamView RemovePlayer(TeamView team, int playerID)
        {
            var playerToDelte = team.Players.Where(p => p.ID == playerID).FirstOrDefault();
            if (playerToDelte != null)
                team.Players.Remove(playerToDelte);
            return team;
        }

        public void CreateTeam(TeamView team)
        {
            //int lastTeamID = 1;
            //var lastTeam = this._teamRepository.GetAll().LastOrDefault();
            //if (lastTeam != null)
            //    lastTeamID += lastTeam.ID + 1;

            //int lastTrainerID = 1;
            //var lastTrainer = this._trainerRepository.GetAll().LastOrDefault();
            //if (lastTrainer != null)
            //    lastTrainerID += lastTrainer.ID + 1;

            //int lastPlayerID = 1;
            //var lastPlayer = this._playerRepository.GetAll().LastOrDefault();
            //if (lastPlayer != null)
            //    lastPlayerID += lastPlayer.ID + 1;

            Team newTeam = new Team
            {
                //newTeam.ID = lastTeamID;
                Name = team.Name,

                Trainer = new Trainer()
                {
                    //ID = lastTrainerID,
                    FirstName = team.Trainer.FirstName,
                    LastName = team.Trainer.LastName,
                    //TeamID = lastTeamID
                }
            };

            ICollection<Player> players = new List<Player>();
            foreach (var player in team.Players)
            {
                players.Add(new Player()
                {
                    //ID = player.ID,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    //TeamID = lastTeamID
                });
            }
            newTeam.Players = players;

            try
            {
                //this._teamRepository.GetDbConnection().Database.BeginTransaction();
                this._teamRepository.Save(newTeam);
                //this._teamRepository.GetDbConnection().Database.CommitTransaction();
            }
            catch(Exception ex)
            {
                //this._teamRepository.GetDbConnection().Database.RollbackTransaction();
            }
        }
    }
}
