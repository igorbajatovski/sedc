using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootballMatchesDemo.Services;
using FootballMatchesDemo.ViewModels;
using FootballMatchesDemo.Models;

namespace FootballMatchesDemo.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamServices _teamServices = null;

        public TeamsController(ITeamServices teamServices)
        {
            this._teamServices = teamServices;
        }

        [HttpGet]
        public IActionResult ListTeams()
        {
            var teams = this._teamServices.GetAllTeams();
            return View(teams);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View(new TeamView());
        }

        [HttpPost]
        public IActionResult AddTeam(TeamView team)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTeam", team);
            }

            if(team.Players.Count < 22)
            {
                team.ErrorMessage = "You need to enter at least 22 playes";
                return View("AddTeam", team);
            }

            this._teamServices.CreateTeam(team);
            return LocalRedirect("/Teams/ListTeams");
        }

        [HttpPost]
        public IActionResult AddPlayer(TeamView team)
        {
            if(!ModelState.IsValid)
            {
                return View("AddTeam", team);
            }


            team = this._teamServices.AddPlayer(team);
            team.Player.FirstName = "";
            team.Player.LastName = "";

            return View("AddTeam", team);
        }
    }
}