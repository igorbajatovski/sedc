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
            ///////////////// Proveri dali ima uplateno livcinja. //////////////////////
            ///////////////// Ako ima moze da se pocne so izvlekuvanje /////////////////
            int pendingTicketsCount = this._ticketRepository.GetAll().Where(t => t.Status == Status.Pending).Count();

            if (pendingTicketsCount == 0)
                throw new Exception("Draw round can not be started, no pending tickets.");

            ////////// Zapisi izvlekuvanje bez dobitnite broevi /////////////
            ////////// Ova oznacuva pocetok na izvlekuvanjeto ///////////////
            var roundResults = new RoundResults() {};
            this._roundResultsRepository.Insert(roundResults);
            this._roundResultsRepository.Save();

            //////////////////// izvlekuvanje na broevi ////////////////////
            Random rand = new Random();
            List<int> winningCombination = new List<int>();
            while (winningCombination.Count < 7)
            {
                int drawedNumber = rand.Next(37);
                if (drawedNumber == 0)
                    continue;
                if (!winningCombination.Exists(n => n == drawedNumber))
                    winningCombination.Add(drawedNumber);
            }
            ////////////////////////////////////////////////////////////////


            ////////////// Najdi dobitni/ne dobitni livcinja //////////////////////////
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

            ////////////////////////////////////////////////////////////////


            ////////////////// Azururaj RoundResult rekord //////////////////
            ////////////////// so dobitno livce. Ova oznacuva ///////////////
            ////////////////// kraj na izvlekuvanjeto ///////////////////////
            roundResults = this._roundResultsRepository.GetAll().Where(r => r.WinningCombination == null).First();
            roundResults.WinningCombination = string.Join(",", winningCombination);
            ////////////////////////////////////////////////////////////////


            ///////////////  Azuriraj dobitni/ne dobitni livcinja //////////
            ///////////////  Azuriraj go balansot na korisnikot   //////////
            ///////////////  ako ima dobitno livce                //////////
            pendingTickets.ForEach(t => this._ticketRepository.Update(t));
            this._roundResultsRepository.Update(roundResults);
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
            return this._ticketRepository.GetAll().Where(t => t.Status == Status.Win).Select(
                t => new TicketModel()
                    {
                        Id = t.Id,
                        AwardBalance = t.AwardBalance,
                        Combination = t.Combination,
                        Round = t.Round,
                        Status = t.Status,
                        UserId = t.UserId
                    }
            );
        }

        public IEnumerable<TicketModel> GetWinningTicktesFromLastRound()
        {
            int lastRoundId = this.GetAll().Where(r => r.WinningCombination != null).Max(r => r.RoundId);
            var winTicketsLastRound = this._ticketRepository.GetAll()
                                          .Where(t => t.Round == lastRoundId && t.Status == Status.Win)
                                          .Select(
                                            t => new TicketModel()
                                              {
                                                  Id = t.Id,
                                                  AwardBalance = t.AwardBalance,
                                                  Combination = t.Combination,
                                                  Round = t.Round,
                                                  Status = t.Status,
                                                  UserId = t.UserId
                                              }
                                            );
            return winTicketsLastRound.ToList();
        }
    }
}
