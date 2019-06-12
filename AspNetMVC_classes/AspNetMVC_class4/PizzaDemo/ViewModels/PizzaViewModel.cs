using PizzaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaDemo.Data;

namespace PizzaDemo.ViewModels
{
    public class PizzaViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage ="PLease enter more then 3 characters")]
        [Display(Name = "Pizza Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Default prize")]
        [Range(typeof(int), "100", "500")]
        public int BasePrise { get; set; }

        [Required]
        [DisplayName("Select ingridients")]
        [MinLength(1, ErrorMessage ="Select at least one ingridient")]
        public List<int> SelectedIngridients { get; set; }

        public List<SelectListItem> AllIngridients { get; set; }

        public PizzaViewModel()
        {
            SelectedIngridients = new List<int>();
            AllIngridients = new List<SelectListItem>();

            foreach (var ingidient in Storage.Ingidients)
            {
                AllIngridients.Add(
                    new SelectListItem(
                        ingidient.Name,
                        ingidient.ID.ToString()
                    ));
            }
        }
    }
}
