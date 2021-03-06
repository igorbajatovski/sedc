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
using FootballMatchesDemo.Data;
using Microsoft.EntityFrameworkCore;
using FootballMatchesDemo.Models;
using FootballMatchesDemo.Services;

namespace FootballMatchesDemo
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient(typeof(DbContext), typeof(FootballMatchesDBContext));
            services.AddTransient(typeof(IRepository<Team>), typeof(TeamsRepository));
            services.AddTransient(typeof(IRepository<Player>), typeof(PlayerRepository));
            services.AddTransient(typeof(IRepository<Trainer>), typeof(TrainerRepository));
            services.AddTransient(typeof(ITeamServices), typeof(TeamServices));

            services.AddDbContext<FootballMatchesDBContext>(
            //    x => x.UseSqlServer(@"Data Source=PETRA16;Initial Catalog=FootballMatches;User ID=sa;Password=Password1"));
            x => x.UseSqlServer(@"Data Source=IGOR01-LPT;Initial Catalog=FootBallMatches;Integrated Security=True"));
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
                    template: "{controller=Teams}/{action=ListTeams}/{id?}");
            });
        }
    }
}
