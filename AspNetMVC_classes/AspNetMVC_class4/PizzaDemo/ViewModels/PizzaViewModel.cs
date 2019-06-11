using PizzaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PizzaDemo.ViewModels
{
    public class PizzaViewModel
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Pizza Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        //[MinLength(1)]
        [Display(Name = "Default prize")]
        [Range(typeof(int), "100", "500")]
        public int BasePrise { get; set; }

        [Required]
        public List<Ingridient> Ingridients { get; set; }

        public PizzaViewModel()
        {

        }
    }
}
