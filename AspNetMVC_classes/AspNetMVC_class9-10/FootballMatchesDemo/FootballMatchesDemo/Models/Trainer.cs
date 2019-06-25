using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMatchesDemo.Models
{
    public class Trainer
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TeamID { get; set; }

        public Team Team { get; set; }

        public Trainer() { }
    }
}
