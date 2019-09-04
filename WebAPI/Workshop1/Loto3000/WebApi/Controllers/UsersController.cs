using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buisnes;
using Models;
using DataModels;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;

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
        [Route("Home")]
        [HttpGet]
        public ActionResult<string> Home()
        {
            return this.Ok("Welcome, this is loto application.");
        }

        // GET api/users
        //[Route("GetAll")]
        //[HttpGet]
        //public ActionResult<IEnumerable<UserModel>> GetAll()
        //{
        //    return this._userService.GetAll().ToList();
        //}

        // GET api/users
        //[Route("GetUserIds")]
        //[HttpGet]
        //public ActionResult<IEnumerable<int>> GetAllById()
        //{
        //    return this._userService.GetAll().Select(u => u.Id).ToList();
        //}

        // POST api/users
        /*
        {
	        "Username": "igor_bajatovski",
            "Password": "Pa$$w0rd",
	        "Firstname": "Igor",
	        "Lastname": "Bajatovski",
        }
        */
        [Route("Register")]
        [HttpPost]
        public IActionResult Register([FromBody] UserModel user)
        {
            try
            {
                this._userService.RegisterUser(user);
                return Ok("User is registered");
            }catch(Exception ex)
            {
                string errMessage = ex.Message;
                while(ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errMessage += "\r\n";
                    errMessage += ex.Message;
                }
                return this.BadRequest(errMessage);
            }
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel user)
        {
            try
            {
                return Ok(this._userService.Authenticate(user));
            }
            catch(Exception ex)
            {
                string errMessage = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errMessage += "\r\n";
                    errMessage += ex.Message;
                }
                return this.BadRequest(errMessage);
            }
        }
    }
}
