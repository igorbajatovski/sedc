using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}
