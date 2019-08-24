using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DataModels;
using System.Linq;

namespace Data
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly string _connectionString;

        public TicketRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("LotoDb");
        }

        public void Delete(Ticket entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.Tickets.Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Ticket> GetAll()
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                return db.Tickets.ToList();
            }
        }

        public void Insert(Ticket entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.Users.Update(entity.User);
                db.Tickets.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Ticket entity)
        {
            using (var db = new LotoDbContext(this._connectionString))
            {
                db.Tickets.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
