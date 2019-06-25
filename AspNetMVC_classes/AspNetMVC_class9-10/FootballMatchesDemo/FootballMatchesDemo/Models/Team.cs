using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMatchesDemo.Models
{
    public class Team
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }

        public Trainer Trainer { get; set; }

        public ICollection<Match> Matches { get; set; }

        public Team() { }
    }
}
