using FootballMatchesDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMatchesDemo.ViewModels
{
    public class TeamView
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must enter name of the team")]
        [StringLength(50, ErrorMessage = "Team name can be maximum of 50 chars")]
        [DisplayName("Team Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "You must enter 22 players")]
        public List<PlayerView> Players { get; set; }

        public TrainerView Trainer { get; set; }

        public PlayerView Player { get; set; }

        public TeamView()
        {
            this.Players = new List<PlayerView>();
        }
    }
}
