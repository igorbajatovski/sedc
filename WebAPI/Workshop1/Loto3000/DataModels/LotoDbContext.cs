using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DataModels
{
    public class LotoDbContext : DbContext
    {
        private readonly string _connectionString;

        public LotoDbContext(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("LotoDb");
        }

        public LotoDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this._connectionString);
            //options.UseSqlServer("Data Source=.;Initial Catalog=LotoDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>()
            //    .HasMany<Ticket>()
            //    .WithOne(t => t.User)
            //    .HasForeignKey(t => t.UserId)
            //    .IsRequired();

            builder.Entity<Ticket>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RoundResults> RoundResults { get; set; }
    }
}
