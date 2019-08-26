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
        [Route("All")]
        [HttpGet]
        public ActionResult<IEnumerable<RoundResultsModel>> Get()
        {
            return this._roundResultsService.GetAll().ToList();
        }

        //// GET: api/DrawRound/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/DrawRound
        [Route("Draw")]
        [HttpPost]
        public void Draw()
        {
            this._roundResultsService.DrawRound();
        }

        //// PUT: api/DrawRound/5
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
