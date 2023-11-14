using API_FirstDemo.Model;
using API_FirstDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_FirstDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _dbContext;
        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get: api/Movies
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_dbContext.movies == null)
            {
                return NotFound();
            }
            return await _dbContext.movies.ToListAsync();
        }

        //Get: api/Movies/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Movie>> GetMovies(int id)
        {
            if (_dbContext.movies == null)
            {
                return NotFound();
            }
            var movie = await _dbContext.movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        //POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }


        //PUT: api/Movies/5
        [HttpPut("{id}")]

        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            Movie old_movie = await _dbContext.movies.FirstOrDefaultAsync(m => m.Id == id);
            if (old_movie == null)
            {
                return NotFound();
            }

            old_movie.Title = movie.Title;
            old_movie.Genre = movie.Genre;
            // old_movie.ReleaseDate = movie.ReleaseDate;
            await _dbContext.SaveChangesAsync();
            return Ok(movie);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            Movie movie=await _dbContext.movies.FirstOrDefaultAsync(m=>m.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            _dbContext.movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}