using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movies.Models;

namespace movies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext ctx = new AppDbContext();

        [HttpGet]
        [Route("/movieslist/{id}")]
        public ObjectResult GetById(int id)
        {
            var movie = ctx.Movies.Where(x => x.id == id).FirstOrDefault();
            if (movie != null)
                return Ok(movie);
            else return NotFound(id);
        }


    }
}
