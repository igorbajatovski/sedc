using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Buisnes
{
    public interface IRoundResultsService
    {
        IEnumerable<RoundResultsModel> GetAll();
        void DrawRound();
        IEnumerable<TicketModel> GetWinningTicktes();
    }
}
