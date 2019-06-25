using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.ViewModels;
using PizzaDemo.Models;
using Microsoft.AspNetCore.Http;

namespace PizzaDemo.Services
{
    public interface IOrderService
    {
        OrderViewModel AddItemToOrder(OrderViewModel orderViewModel);
        List<OrderItem> RecreateOrderItems(IFormCollection collection);
        void CreateOrder(OrderViewModel orderViewModel);
        void UpdateOrder(OrderViewModel orderViewModel);
        void DeleteOrder(OrderViewModel orderViewModel);
    }
}
