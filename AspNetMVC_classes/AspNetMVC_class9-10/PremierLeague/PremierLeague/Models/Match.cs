using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Models
{
    public class Match
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public string Score { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}
