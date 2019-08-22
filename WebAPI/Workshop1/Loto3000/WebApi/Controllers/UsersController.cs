using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buisnes;
using Models;
using DataModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public void Post([FromBody] UserModel user)
        {
            this._userService.RegisterUser(user);
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
