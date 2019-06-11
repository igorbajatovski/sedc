using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class OrderItem
    {
        public PizzaViewModel Pizza { get; set; }

        public int Quantity { get; set; }

        public SizeEnum Size { get; set; }

        public OrderItem(PizzaViewModel pizza, int quantity, SizeEnum size)
        {
            this.Pizza = pizza;
            this.Quantity = quantity;
            this.Size = size;
        }
    }
}
