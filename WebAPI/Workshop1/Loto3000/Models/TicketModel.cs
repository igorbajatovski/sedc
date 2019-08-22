using System;
using System.Collections.Generic;
using System.Text;
using DataModels;

namespace Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        
        public string Combination { get; set; }

        public int UserId { get; set; }

        public int Round { get; set; }

        public Status Status { get; set; }

        public int AwardBalance { get; set; }
    }
}
