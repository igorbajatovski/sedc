using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buisnes;
using Models;
using DataModels;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        
        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            return this._userService.GetAll().ToList();
        }

        //// GET api/users/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/users
        /*
        {
	        "Username": "igorbajatovski@gmail.com",
	        "Firstname": "Igor",
	        "Lastname": "Bajatovski",
	        "Balance": 1000,
	        "Role": 2
        }
        */
        [HttpPost]
        public IActionResult Post([FromBody] UserModel user)
        {
            try
            {
                this._userService.RegisterUser(user);
                return Ok("User is registered");
            }catch(Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        //// PUT api/users/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/users/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
