using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchesDemo.Models;

namespace FootballMatchesDemo.Data
{
    public class FootballMatchesDBContext : DbContext
    {
        public FootballMatchesDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Player> Cinemas { get; set; }
        public DbSet<Team> Movies { get; set; }
        public DbSet<Trainer> Halls { get; set; }
        public DbSet<Match> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasKey(t => t.ID);
            modelBuilder.Entity<Team>().HasMany<Player>(t => t.Players).WithOne(p => p.Team).HasForeignKey(p => p.TeamID);

            modelBuilder.Entity<Team>().HasOne<Trainer>(x => x.Trainer).WithOne(x => x.Team).HasForeignKey(x => x.)
        }
    }
}
