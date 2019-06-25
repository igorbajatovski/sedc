using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.ViewModels;
using PizzaDemo.Data;
using PizzaDemo.Models;
using Microsoft.AspNetCore.Http;

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
            //if (SessionData.Data.ContainsKey("OrderedItems"))
            //    orderViewModel.OrderedItems = (List<OrderItem>)SessionData.Data["OrderedItems"];

            if (orderViewModel.OrderedItems.Count == 0)
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

            //SessionData.Data["OrderedItems"] = orderViewModel.OrderedItems;

            return orderViewModel;
        }

        public List<OrderItem> RecreateOrderItems(IFormCollection collection)
        {
            List<OrderItem> orderedItems = new List<OrderItem>();
            OrderItem orderedItem = null;
            int index = 0;
            for (int i = 0; i < collection.Keys.Count; ++i)
            {
                var key = collection.Keys.ElementAt(i);
                if(key.Contains($"orderedPizza[{index}]"))
                {
                    if (orderedItem == null)
                        orderedItem = new OrderItem();
                    
                    // OrderID
                    orderedItem.ID = index + 1;

                    // Pizza
                    orderedItem.Pizza = this._pizzaRepository.GetById(int.Parse(collection[key].ToString()));

                    // Size
                    key = collection.Keys.ElementAt(i + 1);
                    orderedItem.Size = (SizeEnum)typeof(SizeEnum).GetField(collection[key].ToString()).GetValue(null);

                    // Quantity
                    key = collection.Keys.ElementAt(i + 2);
                    orderedItem.Quantity = int.Parse(collection[key].ToString());

                    i += 2;
                    ++index;
                    orderedItems.Add(orderedItem);
                }
            }
            return orderedItems;
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
