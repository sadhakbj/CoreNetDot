using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movies.Models;
using Newtonsoft.Json;

namespace movies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {

        private AppDbContext ctx = new AppDbContext();

        public MoviesController()
        {
        }

        [HttpGet]
        [Route("/movies/{id}")]
        public Movie GetById(int id)
        {
            var movie = ctx.Movies.Where(x => x.id == id).FirstOrDefault();
            return movie;
        }

        [HttpGet]
        [Route("/cinemas")]
        public IEnumerable<Movie> GetAllMovies()
        {
            var moviesList = ctx.Movies.Where(x => x.TicketPrice > 10);

            return moviesList;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateMovie(Movie data)
        {
            var movie = ctx.Movies.Add(data).Entity;

            ctx.SaveChanges();

            return Ok(movie);
            // return CreatedAtAction(nameof(GetById), new { id = movie.id }, movie);
        }

    }
}
