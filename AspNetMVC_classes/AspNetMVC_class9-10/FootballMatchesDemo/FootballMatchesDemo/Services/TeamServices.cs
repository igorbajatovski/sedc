using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchesDemo.Data;
using FootballMatchesDemo.Models;
using FootballMatchesDemo.ViewModels;

namespace FootballMatchesDemo.Services
{
    public class TeamServices : ITeamServices
    {
        private readonly IRepository<Team> _teamRepository = null;
        private readonly IRepository<Trainer> _trainerRepository = null;
        private readonly IRepository<Player> _playerRepository = null;

        public TeamServices(IRepository<Team> teamRepository, IRepository<Trainer> trainerRepository, IRepository<Player> playerRepository)
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

        public void CreateTeam(TeamView team)
        {
            int lastTeamID = 0;
            var lastTeam = this._teamRepository.GetAll().LastOrDefault();
            if (lastTeam != null)
                lastTeamID += 1;

            int lastTrainerID = 0;
            var lastTrainer = this._trainerRepository.GetAll().LastOrDefault();
            if (lastTrainer != null)
                lastTrainerID += 1;

            int lastPlayerID = 0;
            var lastPlayer = this._playerRepository.GetAll().LastOrDefault();
            if (lastPlayer != null)
                lastPlayerID += 1;

            Team newTeam = new Team();
            newTeam.ID = lastTeamID;
            newTeam.Name = team.Name;
            newTeam.Trainer = new Trainer() { };
        }
    }
}
