using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMatchesDemo.Models
{
    public class Match
    {   
        public Team GuestTeam { get; set; }

        public Team HomeTeam { get; set; }

        public int GuestTeamID { get; set; }

        public int HomeTeamID { get; set; }

        public Score Score { get; set; }

        public Match() { }
    }
}
