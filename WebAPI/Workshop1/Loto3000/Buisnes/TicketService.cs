using System;
using System.Collections.Generic;
using System.Text;
using DataModels;
using Models;
using Data;
using System.Linq;

namespace Buisnes
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<User> userRepository, IRepository<Ticket> ticketRepository)
        {
            this._userRepository = userRepository;
            this._ticketRepository = ticketRepository;
        }

        public IEnumerable<TicketModel> GetAll()
        {
            return this._ticketRepository.GetAll().Select(t => new TicketModel()
            {
                Id = t.Id,
                Combination = t.Combination,
                UserId = t.UserId,
                Round = t.Round,
                AwardBalance = t.AwardBalance,
                Status = t.Status
            });
        }

        public void RegisterTicket(TicketModel ticket)
        {
            throw new NotImplementedException();
        }
    }
}
