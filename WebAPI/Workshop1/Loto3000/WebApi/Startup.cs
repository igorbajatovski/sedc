﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Data;
using Buisnes;
using Data;
using DataModels;
using Microsoft.EntityFrameworkCore;

namespace WebApi
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
            services.AddSingleton(this.Configuration);
            services.AddSingleton<DbContext, LotoDbContext>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Ticket>, TicketRepository>();
            services.AddTransient<IRepository<RoundResults>, RoundResultsRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IRoundResultsService, RoundResultsService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(setup => setup.AddPolicy("AllowAnyOrigin", conf => {
                                                                                    conf.AllowAnyOrigin();
                                                                                    conf.AllowAnyMethod();
                                                                                    conf.AllowAnyHeader();
                                                                                }
                ));
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
                app.UseHsts();
            }
            app.UseCors("AllowAnyOrigin");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}