using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class OrderItem
    {
        public Pizza Pizza { get; set; }

        public int Quantity { get; set; }

        public SizeEnum Size { get; set; }

        public OrderItem(Pizza pizza, int quantity, SizeEnum size)
        {
            this.Pizza = pizza;
            this.Quantity = quantity;
            this.Size = size;
        }
    }
}
