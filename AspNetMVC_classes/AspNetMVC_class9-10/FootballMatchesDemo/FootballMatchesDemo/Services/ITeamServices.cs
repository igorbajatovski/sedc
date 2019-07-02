using FootballMatchesDemo.Models;
using FootballMatchesDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMatchesDemo.Services
{
    public interface ITeamServices
    {
        ICollection<Team> GetAllTeams();
        TeamView AddPlayer(TeamView team);
        TeamView RemovePlayer(TeamView team, int playerID);
        void CreateTeam(TeamView team);
    }
}
