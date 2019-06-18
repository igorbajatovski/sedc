using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class Order : IEntity
    {
        public int ID { get; set; }

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

        public Order(int id, List<OrderItem> items, User user, DateTime orderDate)
        {
            this.ID = id;
            this.Items = items;
            this.User = user;
            this.OrderDate = orderDate;
        }
    }
}
