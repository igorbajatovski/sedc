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

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Match> Matches { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Data Source=IGOR01-LPT;Initial Catalog=FootBallMatches;Integrated Security=True");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasKey(t => t.ID);
            modelBuilder.Entity<Player>().HasKey(t => t.ID);
            modelBuilder.Entity<Team>()
                .HasMany<Player>(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamID);

            modelBuilder.Entity<Trainer>().HasKey(t => t.ID);
            modelBuilder.Entity<Team>()
                .HasOne<Trainer>(x => x.Trainer)
                .WithOne(x => x.Team)
                .HasForeignKey<Trainer>(x => x.TeamID);

            //modelBuilder.Entity<Trainer>()
            //    .HasOne<Team>(t => t.Team)
            //    .WithOne(t => t.Trainer)
            //    .HasForeignKey<Trainer>(t => t.);

            modelBuilder.Entity<Match>().HasKey(m => new { m.HomeTeamID, m.GuestTeamID });

            modelBuilder.Entity<Team>()
                .HasMany<Match>(t => t.HomeMatches)
                .WithOne(t => t.HomeTeam)
                .HasForeignKey(t => t.HomeTeamID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Team>()
                .HasMany<Match>(t => t.GuestMatches)
                .WithOne(t => t.GuestTeam)
                .HasForeignKey(t => t.GuestTeamID).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Match>()
            //    .HasOne(t => t.GuestTeam)
            //    .WithMany(t => t.GuestMatches)
            //    .HasForeignKey(m => m.GuestTeamID);
            //modelBuilder.Entity<Match>()
            //    .HasOne(t => t.HomeTeam)
            //    .WithMany(t => t.HomeMatches)
            //    .HasForeignKey(m => m.HomeTeamID);
        }
    }
}
