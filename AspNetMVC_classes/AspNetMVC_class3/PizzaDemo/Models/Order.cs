using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class Order
    {
        public List<OrderItem> Items { set; get; }

        public User User { set; get; }

        public DateTime OrderDate { get; set; }

        public int TotalPrize
        {
            get
            {
                int _totalPrize = 0;
                Array.ForEach(Items.ToArray(), item =>
                {
                    _totalPrize += item.Pizza.getPrize(item.Size) * item.Quantity;
                });
                return _totalPrize;
            }
        }

        public Order(List<OrderItem> items, User user, DateTime orderDate)
        {
            this.Items = items;
            this.User = user;
            this.OrderDate = orderDate;
        }
    }
}
