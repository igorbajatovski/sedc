﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaDemo.Services;
using PizzaDemo.Data;
using PizzaDemo.Models;
using PizzaDemo.ViewModels;

namespace PizzaDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // First add the Repository
            //services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            //Second add the Service
            //services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient(typeof(IRepository<Pizza>), typeof(PizzaRepository));
            services.AddTransient(typeof(IRepository<Ingridient>), typeof(IngridientsRepository));
            services.AddTransient<IPizzaService, PizzaService>();

            services.AddTransient(typeof(IRepository<Order>), typeof(OrderRepository));
            services.AddTransient<IOrderService, OrderService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pizza}/{action=Menu}/{id?}");
            });
        }
    }
}
