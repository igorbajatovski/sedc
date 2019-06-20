using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaDemo.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "First name of user is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Length of first name must be between 1 and 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name of user is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Length of last name must be between 1 and 50 characters")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone numer is required")]
        [RegularExpression("(\\+389) *[0-9]{3}/[0-9]{3}-[0-9]{3,4}", ErrorMessage = "Wrong phone number format")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address of user is required")]
        public string Address { get; set; }
    }
}
