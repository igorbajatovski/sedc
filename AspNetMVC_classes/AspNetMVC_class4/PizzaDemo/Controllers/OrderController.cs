﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDemo.ViewModels;
using PizzaDemo.Models;
using PizzaDemo.Services;
using Microsoft.AspNetCore.Http;
using PizzaDemo.Data;

namespace PizzaDemo.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPizzaService _pizzaService = null;
        private readonly IOrderService _orderService = null;

        public OrderController(IPizzaService pizzaService, IOrderService orderService)
        {
            this._pizzaService = pizzaService;
            this._orderService = orderService;
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel(this._pizzaService);
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
                return View(new OrderViewModel(this._pizzaService, orderViewModel));

            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult AddItemToOrderPostData(OrderViewModel orderViewModel, IFormCollection colllection)
        {
            if (!ModelState.IsValid)
                return View("Create", new OrderViewModel(this._pizzaService, orderViewModel));

            var orderedItems = this._orderService.RecreateOrderItems(colllection);
            orderViewModel.OrderedItems = orderedItems;
            orderViewModel = this._orderService.AddItemToOrder(orderViewModel);
            
            return View("Create", new OrderViewModel(this._pizzaService, orderViewModel));
        }

        [HttpPost]
        public IActionResult AddItemToOrderPostData2(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
                return View("Create", new OrderViewModel(this._pizzaService, orderViewModel));

            orderViewModel = this._orderService.AddItemToOrder(orderViewModel);

            return View("Create", new OrderViewModel(this._pizzaService, orderViewModel));
        }
    }
}