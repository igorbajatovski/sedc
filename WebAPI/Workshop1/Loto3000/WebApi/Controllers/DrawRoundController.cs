using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Buisnes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawRoundController : ControllerBase
    {
        private readonly IRoundResultsService _roundResultsService;

        public DrawRoundController(IRoundResultsService roundResultsService)
        {
            this._roundResultsService = roundResultsService;
        }

        // GET: api/DrawRound
        [Route("GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<RoundResultsModel>> GetAll()
        {
            try
            {
                var allRounds = this._roundResultsService.GetAll().ToList();
                return allRounds;
            }catch(Exception ex)
            {
                string errMessage = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errMessage += "\\r\\n";
                    errMessage += ex.Message;
                }
                return this.BadRequest(errMessage);
            }
        }

        // GET: api/DrawRound
        [Route("GetWinningTickets")]
        [HttpGet]
        public ActionResult<IEnumerable<TicketModel>> GetWinningTickets()
        {
            try
            {
                var winningTickets = this._roundResultsService.GetWinningTicktes().ToList();
                return winningTickets;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errMessage += "\\r\\n";
                    errMessage += ex.Message;
                }
                return this.BadRequest(errMessage);
            }
        }

        // POST: api/DrawRound
        [Route("Draw")]
        [HttpGet]
        public IActionResult Draw()
        {
            try
            {
                this._roundResultsService.DrawRound();
                return this.Ok();
            }catch(Exception ex)
            {
                string errMessage = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errMessage += "\\r\\n";
                    errMessage += ex.Message;
                }
                return this.BadRequest(errMessage);
            }
        }
    }
}
