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
        public ActionResult<IEnumerable<TicketModel>> Get()
        {
            return this._ticketService.GetAll().ToList();
        }

        //// GET: api/Tickets/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Tickets
        [HttpPost]
        public void Post([FromBody] TicketModel ticketModel)
        {
            this._ticketService.RegisterTicket(ticketModel);
        }

        //// PUT: api/Tickets/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
