using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerId { get; set; }
        public ICollection<Match> HomeMatches { get; set; }
        public ICollection<Match> AwayMatches { get; set; }
    }
}
