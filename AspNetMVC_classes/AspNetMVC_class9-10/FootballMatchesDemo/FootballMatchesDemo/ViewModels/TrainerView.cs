using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMatchesDemo.ViewModels
{
    public class TrainerView
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must enter first name of trainer for the team")]
        [StringLength(50, ErrorMessage = "Team name can be maximum of 50 chars")]
        [DisplayName("Trainer First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter last name of trainer for the team")]
        [StringLength(50, ErrorMessage = "Team name can be maximum of 50 chars")]
        [DisplayName("Trainer Last Name")]
        public string LastName { get; set; }

        public TrainerView() { }
    }
}
