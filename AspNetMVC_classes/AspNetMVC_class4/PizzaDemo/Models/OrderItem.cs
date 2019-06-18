using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class OrderItem : IEntity
    {
        public int ID { get; set; }

        public Pizza Pizza { get; set; }

        public int Quantity { get; set; }

        public SizeEnum Size { get; set; }

        public OrderItem(int id, Pizza pizza, int quantity, SizeEnum size)
        {
            this.ID = id;
            this.Pizza = pizza;
            this.Quantity = quantity;
            this.Size = size;
        }
    }
}
