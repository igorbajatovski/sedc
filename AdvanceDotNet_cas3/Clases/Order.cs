using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Order
    {
        private List<OrderLine> _orderLines = new List<OrderLine>();

        public void AddOrderLine(string product, int quantity, double price)
        {
            OrderLine orderLine = new OrderLine() { ProductName = product, Quantity = quantity, Price = price };
            _orderLines.Add(orderLine);
        }

        public double OrderTotal()
        {
            double total = 0;
            foreach(var orderLine in _orderLines)
                total += orderLine.OrderLineTotal();
            return total;
        }

        private class OrderLine
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

            public double OrderLineTotal()
            {
                return this.Price * this.Quantity;
            }
        }

    }
}
