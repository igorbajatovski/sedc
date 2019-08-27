using System;
using System.Collections.Generic;
using System.Text;
using DataModels;
using Models;
using Data;
using System.Linq;

namespace Buisnes
{
    public class RoundResultsService : IRoundResultsService
    {
        private readonly IRepository<RoundResults> _roundResultsRepository;
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<User> _userRepository;

        public RoundResultsService(IRepository<RoundResults> roundResultsRepository,
                                   IRepository<Ticket> ticketRepository,
                                   IRepository<User> userRepository
                                   )
        {
            this._roundResultsRepository = roundResultsRepository;
            this._ticketRepository = ticketRepository;
            this._userRepository = userRepository;
        }

        public void DrawRound()
        {
            //////////////////// izvlekuvanje na broevi ////////////////////
            Random rand = new Random(1);
            List<int> winningCombination = new List<int>();
            while (winningCombination.Count < 7)
            {
                int drawedNumber = rand.Next(37);
                if (!winningCombination.Exists(n => n == drawedNumber))
                    winningCombination.Add(drawedNumber);
            }
            ////////////////////////////////////////////////////////////////

            var pendingTickets = this._ticketRepository.GetAll().Where(t => t.Status == Status.Pending).ToList();

            pendingTickets.ForEach(t =>
            {
                var ticketInfo = CheckTicket(t, winningCombination);
                t.Status = ticketInfo.Status;

                if (ticketInfo.Status == Status.Win)
                {
                    switch (ticketInfo.winNumbersCount)
                    {
                        case 4:
                            {
                                t.AwardBalance = 50 * 10;
                                break;
                            }
                        case 5:
                            {
                                t.AwardBalance = 50 * 100;
                                break;
                            }
                        case 6:
                            {
                                t.AwardBalance = 50 * 1000;
                                break;
                            }
                        case 7:
                            {
                                t.AwardBalance = 50 * 10000;
                                break;
                            }
                    }
                }// end of if

                var user = this._userRepository.GetAll().Where(u => u.Id == t.UserId).First();

                t.User = user;
                t.User.Balance += t.AwardBalance;
            });

            var roundResults = new RoundResults()
            {
                WinningCombination = string.Join(",", winningCombination)
            };

            pendingTickets.ForEach(t => this._ticketRepository.Update(t));
            this._roundResultsRepository.Insert(roundResults);
            this._roundResultsRepository.Save();
        }

        private class TicketInfo
        {
            public Status Status { get; set; }
            public int winNumbersCount { get; set; }
        }

        private TicketInfo CheckTicket(Ticket ticket, List<int> winningCombination)
        {
            // Put ticket numbers into a int array
            string[] split = ticket.Combination.Split(',');
            List<int> numbers = new List<int>(7);

            Array.ForEach(split, s => numbers.Add(int.Parse(s)));

            int winNumbersCount = 0;
            foreach (var wN in winningCombination)
            {
                foreach (var num in numbers)
                {
                    if (wN == num)
                        ++winNumbersCount;
                }
            }

            if (winNumbersCount > 3)
                return new TicketInfo { Status = Status.Win, winNumbersCount = winNumbersCount };
            return new TicketInfo { Status = Status.Lose, winNumbersCount = winNumbersCount };
        }

        public IEnumerable<RoundResultsModel> GetAll()
        {
            return this._roundResultsRepository.GetAll().Select(r => new RoundResultsModel()
            {
                RoundId = r.RoundId,
                WinningCombination = r.WinningCombination
            });
        }

        public IEnumerable<TicketModel> GetWinningTicktes()
        {
            throw new NotImplementedException();
        }
    }
}
