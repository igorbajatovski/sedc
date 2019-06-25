using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaDemo.Models;
using PizzaDemo.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
//using PizzaDemo.Data;

namespace PizzaDemo.ViewModels
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }

        public UserViewModel User { get; set; }

        //[BindProperty(BinderType = typeof(List<OrderItem>))]
        public List<OrderItem> OrderedItems { get; set; }

        //++++++++++++++++++  Selected Pizza ++++++++++++++++++++++++
        [DisplayName("Select Pizza")]
        public int SelectedPizza { get; set; }

        public List<SelectListItem> AllPizzas { get; set; }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //++++++++++++++++++  Selected Size ++++++++++++++++++++++++
        [DisplayName("Select size")]
        public SizeEnum SelectedSize { get; set; }

        public List<SelectListItem> AllSizes { get; set; }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //++++++++++++++++++  Selected Quantity ++++++++++++++++++++++++
        [DisplayName("Select quantity")]
        public int SelectedQuantity { get; set; }

        public List<SelectListItem> AllQuantities { get; set; }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public OrderViewModel()
        {
            this.OrderedItems = new List<OrderItem>();
        }

        public OrderViewModel(IPizzaService pizzaService)
        {   
            this.OrderedItems = new List<OrderItem>();

            this.SelectedPizza = 0;
            this.AllPizzas = new List<SelectListItem>();
            this.AllPizzas.Add(new SelectListItem(text: "Select Pizza", value: "0", selected: true, disabled: true));
            foreach(var pizza in pizzaService.GetAllPizzas())
            {
                this.AllPizzas.Add(new SelectListItem(text: pizza.Name, value: pizza.ID.ToString()));
            }


            this.SelectedSize = 0;
            this.AllSizes = new List<SelectListItem>();
            this.AllSizes.Add(new SelectListItem(text: "Select size", value: "0", selected: true, disabled: true));
            int count = 1;
            foreach (var size in typeof(SizeEnum).GetEnumNames())
            {
                this.AllSizes.Add(new SelectListItem(text: size, value: count.ToString()));
                ++count;
            }


            this.SelectedQuantity = 0;
            this.AllQuantities = new List<SelectListItem>();
            this.AllQuantities.Add(new SelectListItem(text: "Select quantity", value: "0", selected: true, disabled: true));
            for(int i = 1; i <= pizzaService.MaxPizzasToOrder(); ++i)
            {
                this.AllQuantities.Add(new SelectListItem(text: i.ToString(), value: i.ToString()));
            }
        }

        public OrderViewModel(IPizzaService pizzaService, OrderViewModel orderViewModel) : this(pizzaService)
        {
            this.OrderID = orderViewModel.OrderID;
            this.OrderedItems = orderViewModel.OrderedItems;
            this.SelectedPizza = 0;
            this.SelectedQuantity = 0;
            this.SelectedSize = 0;
            this.User = orderViewModel.User;
        }

        public int TotalPrize
        {
            get
            {
                int _totalPrize = 0;
                Array.ForEach(OrderedItems.ToArray(), item =>
                {
                    _totalPrize += item.Pizza.getPrize(item.Size) * item.Quantity;
                });
                return _totalPrize;
            }
        }

    }
}
