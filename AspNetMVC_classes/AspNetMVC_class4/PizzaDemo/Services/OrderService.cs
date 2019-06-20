using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.ViewModels;
using PizzaDemo.Data;
using PizzaDemo.Models;

namespace PizzaDemo.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository = null;
        private readonly IRepository<Pizza> _pizzaRepository = null;

        public OrderService(IRepository<Pizza> pizzaRepository, IRepository<Order> orderRepository)
        {
            this._pizzaRepository = pizzaRepository;
            this._orderRepository = orderRepository;
        }

        public OrderViewModel AddItemToOrder(OrderViewModel orderViewModel)
        {
            if(orderViewModel.OrderedItems.Count == 0)
            {
                OrderItem orderItem = new OrderItem(1, this._pizzaRepository.GetById(orderViewModel.SelectedPizza),
                                                    orderViewModel.SelectedQuantity, orderViewModel.SelectedSize);
                orderViewModel.OrderedItems.Add(orderItem);
            }
            else
            {
                int nextID = orderViewModel.OrderedItems.Last().ID + 1;
                OrderItem orderItem = new OrderItem(nextID, this._pizzaRepository.GetById(orderViewModel.SelectedPizza),
                                                    orderViewModel.SelectedQuantity, orderViewModel.SelectedSize);
                orderViewModel.OrderedItems.Add(orderItem);
            }
            return orderViewModel;
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(OrderViewModel orderViewModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
