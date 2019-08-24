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
        private readonly IRepository<RoundResults> _roundResultsRepository;
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<User> userRepository, IRepository<RoundResults> roundResultsRepository, IRepository<Ticket> ticketRepository)
        {
            this._userRepository = userRepository;
            this._roundResultsRepository = roundResultsRepository;
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
            ValidateTicket(ticket);

            var lastRound = this._roundResultsRepository.GetAll().Count();

            var ticketUser = this._userRepository.GetAll().Where(u => u.Id == ticket.UserId).First();
            ticketUser.Balance -= 50;

            this._ticketRepository.Insert(new Ticket()
            {
                //Id = ticket.Id,
                Combination = ticket.Combination,
                UserId = ticket.UserId,
                AwardBalance = 0,
                Round = lastRound + 1,
                Status = Status.Pending,
                User = ticketUser
            });
        }

        public void ValidateTicket(TicketModel ticket)
        {
            if (ticket.Combination.Length > 20)
                throw new Exception("Value for loto combination too large");

            var comb = ticket.Combination.Split(',');
            if(comb.Length < 7)
                throw new Exception("Loto combination containes less then 7 digits");

            if (comb.Length > 7)
                throw new Exception("Loto combination containes more then 7 digits");

            Array.ForEach(comb, e =>
            {
                if (!int.TryParse(e, out int number))
                    throw new Exception($"Loto number \"{e}\" is not a number");
                if (number < 1 || number > 37)
                    throw new Exception($"Selected number \"{number}\" is not between 1 and 37");
            });

            var ticketUser = this._userRepository.GetAll().Where(u => u.Id == ticket.UserId).FirstOrDefault();
            if(ticket == null)
                throw new Exception("Ticket user does not exist");
        }
    }
}
