using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>()
        {
            new Movie(1, "Rambo", 120, "Action"),
            new Movie(2, "Terminator", 115, "Action/Sc-Fi"),
            new Movie(3, "Ace Ventura", 95, "Comedy")
        };

        public MovieController()
        {

        }
        
        // GET: api/Movie
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return _movies;
        }

        // GET: api/Movie/5
        [HttpGet]
        [Route("ByID/{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.ID == id);
            if (movie == null)
                return this.NotFound();
            return Ok(movie);
        }

        [HttpGet]
        [Route("ByName/{name}")]
        public ActionResult<Movie> Get(string name)
        {
            var movie = _movies.FirstOrDefault(m => m.Name == name);
            if (movie == null)
                return this.NotFound();
            return Ok(movie);
        }

        // POST: api/Movie
        [HttpPost]
        [Route("AddMovie/")]
        public void Post([FromBody] Movie movie)
        {
            _movies.Add(movie);
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie value)
        {
            //var movie = _movies.FirstOrDefault(m => m.ID == id);
            int index = _movies.FindIndex(m => m.ID == id);
            _movies[index] = value;
            //movie.ID = value.ID;
            //movie.Name = value.Name;
            //movie.Length = value.Length;
            //movie.Genre = value.Genre;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.ID == id);
            _movies.Remove(movie);
        }
    }
}
