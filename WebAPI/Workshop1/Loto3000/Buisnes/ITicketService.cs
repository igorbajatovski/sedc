using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Buisnes
{
    public interface ITicketService
    {
        IEnumerable<TicketModel> GetAll();
        void RegisterTicket(TicketModel ticket);
        void ValidateTicket(TicketModel ticket);
    }
}
