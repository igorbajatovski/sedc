using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballMatchesDemo.Models
{
    public class Team
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }

        public Trainer Trainer { get; set; }

        public ICollection<Match> HomeMatches { get; set; }

        public ICollection<Match> GuestMatches { get; set; }

        public Team() { }
    }
}
