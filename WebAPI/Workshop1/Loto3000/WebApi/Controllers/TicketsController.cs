using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Buisnes;
using Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            this._ticketService = ticketService;
        }

        // GET: api/Tickets
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<TicketModel>> GetAll()
        {
            return this._ticketService.GetAll().ToList();
        }

        // POST: api/Tickets
        /*
         * {
         *      "UserId": 1,
         *      "Combination": "1,2,3,4,5,6,7"
         * }
         */
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] TicketModel ticketModel)
        {
            try
            {
                this._ticketService.RegisterTicket(ticketModel);
                return this.Ok($"Ticket \"{ticketModel.Combination}\" for user \"{ticketModel.UserId}\" is registered");
            }catch(Exception ex)
            {
                string errorMsg = ex.Message;
                while(ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errorMsg += "\\r\\n" + ex.Message;
                }
                return this.BadRequest(errorMsg);
            }
        }
    }
}
