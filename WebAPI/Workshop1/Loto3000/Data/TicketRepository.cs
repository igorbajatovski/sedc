using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DataModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly LotoDbContext _lotoDB;

        public TicketRepository(DbContext lotoDB)
        {
            this._lotoDB = (LotoDbContext)lotoDB;
        }

        public void Delete(Ticket entity)
        {
            lock (_lotoDB)
                _lotoDB.Tickets.Remove(entity);
        }

        public IEnumerable<Ticket> GetAll()
        {
            lock (_lotoDB)
                return _lotoDB.Tickets.AsEnumerable();
        }

        public void Insert(Ticket entity)
        {
            lock (_lotoDB)
            {
                _lotoDB.Users.Update(entity.User);
                _lotoDB.Tickets.Add(entity);
            }
        }

        public int Save()
        {
            lock (_lotoDB)
                return _lotoDB.SaveChanges();
        }

        public void Update(Ticket entity)
        {
            lock (_lotoDB)
            {
                _lotoDB.Users.Update(entity.User);
                _lotoDB.Tickets.Update(entity);
            }
        }
    }
}
