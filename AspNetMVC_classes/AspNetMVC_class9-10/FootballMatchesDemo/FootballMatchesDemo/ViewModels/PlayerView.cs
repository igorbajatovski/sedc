using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMatchesDemo.ViewModels
{
    public class PlayerView
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50, ErrorMessage = "Team name can be maximum of 50 chars")]
        [DisplayName("Player First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50, ErrorMessage = "Team name can be maximum of 50 chars")]
        [DisplayName("Player Last Name")]
        public string LastName { get; set; }
    }
}
