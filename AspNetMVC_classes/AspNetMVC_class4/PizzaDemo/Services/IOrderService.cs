using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.ViewModels;
using PizzaDemo.Models;

namespace PizzaDemo.Services
{
    public interface IOrderService
    {
        OrderViewModel AddItemToOrder(OrderViewModel orderViewModel);
        void CreateOrder(OrderViewModel orderViewModel);
        void UpdateOrder(OrderViewModel orderViewModel);
        void DeleteOrder(OrderViewModel orderViewModel);
    }
}
