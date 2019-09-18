using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Buisnes;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DrawRoundController : ControllerBase
    {
        private readonly IRoundResultsService _roundResultsService;
        private readonly IUserService _userService;

        public DrawRoundController(IRoundResultsService roundResultsService, IUserService userService)
        {
            this._roundResultsService = roundResultsService;
            this._userService = userService;
        }

        // GET: api/DrawRound
        [Route("GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<RoundResultsModel>> GetAll()
        {
            try
            {
                var adminUserID = GetAuthorizedUserId();
                if (!this._userService.IsAdminUser(adminUserID))
                    return this.BadRequest($"User with ID {adminUserID} is not an administrator");
                var allRounds = this._roundResultsService.GetAll().ToList();
                return allRounds;
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

        // GET: api/DrawRound
        [Route("GetWinningTickets")]
        [HttpGet]
        public ActionResult<IEnumerable<TicketModel>> GetWinningTickets()
        {
            try
            {
                var adminUserID = GetAuthorizedUserId();
                if (!this._userService.IsAdminUser(adminUserID))
                    return this.BadRequest($"User with ID {adminUserID} is not an administrator");
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

        // GET: api/DrawRound
        [Route("GetWinningTicketsLastRound")]
        [HttpGet]
        public ActionResult<IEnumerable<TicketModel>> GetWinningTicketsFromLastRound()
        {
            try
            {
                var adminUserID = GetAuthorizedUserId();
                if (!this._userService.IsAdminUser(adminUserID))
                    return this.BadRequest($"User with ID {adminUserID} is not an administrator");
                var winningTickets = this._roundResultsService.GetWinningTicktesFromLastRound().ToList();
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
        [HttpPost]
        public IActionResult Draw()
        {
            try
            {
                var adminUserID = GetAuthorizedUserId();
                if (!this._userService.IsAdminUser(adminUserID))
                    return this.BadRequest($"User with ID {adminUserID} is not an administrator");
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

        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out var userId))
            {
                throw new Exception("Name Identifier claim does not exist.");
            }

            return userId;
        }
    }
}
