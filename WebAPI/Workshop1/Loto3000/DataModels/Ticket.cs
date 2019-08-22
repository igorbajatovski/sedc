using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20)]
        public string Combination { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int Round { get; set; }

        public Status Status { get; set; }

        public int AwardBalance { get; set; }
    }
}
