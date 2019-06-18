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
        public int ID { get; set; }

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

        public PizzaViewModel(string name, string description, int basePrise, List<int> selectedIngridients)
        {
            this.Name = name;
            this.Description = description;
            this.BasePrise = basePrise;
            this.SelectedIngridients = selectedIngridients;

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

        //public Pizza ToModel()
        //{
        //    List<Ingridient> ingridient = new List<Ingridient>();
        //    foreach (var ingre in this.SelectedIngridients)
        //    {
        //        var _ingre = Storage.Ingidients.Where(i => i.ID == ingre).FirstOrDefault();
        //        if (_ingre != null)
        //            ingridient.Add(_ingre);
        //    }

        //    Pizza _pizza = new Pizza(this.ID, this.Name, this.Description, ingridient, this.BasePrise);

        //    return _pizza;
        //}
    }
}
