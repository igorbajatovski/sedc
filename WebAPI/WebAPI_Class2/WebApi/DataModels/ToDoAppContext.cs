using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    class ToDoAppContext : DbContext
    {
        private readonly string _connectionString;

        public ToDoAppContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this._connectionString);
            //options.UseSqlServer("Data Source=.;Initial Catalog=ToDoDb;User ID=sa;Password=Password1");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DtoUser>()
                .HasMany<DtoToDoItem>()
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);
        }

        public DbSet<DtoUser> Users { get; set; }
        public DbSet<DtoToDoItem> ToDoItems { get; set; }
    }
}
