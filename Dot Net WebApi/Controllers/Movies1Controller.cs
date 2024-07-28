using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dot_Net_WebApi.Data;
using Dot_Net_WebApi.Models;
using Dot_Net_WebApi.Domain;

namespace Dot_Net_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movies1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Movies1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies1
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
          if (_context.Movies == null)
          {
              return NotFound();
          }
            return await _context.Movies.ToListAsync();
        }*/

       /* [HttpGet]
        public async Task<ActionResult<PagedResult<Movie>>> GetMovies([FromQuery] Pagination pagination)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }

            var totalItems = await _context.Movies.CountAsync();
            var pagedMovies = await _context.Movies
                                            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                            .Take(pagination.PageSize)
                                            .ToListAsync();

            var pagedResult = new PagedResult<Movie>(pagedMovies, totalItems, pagination.PageNumber, pagination.PageSize);
            return Ok(pagedResult);
        }*/

        [HttpGet]
        public async Task<ActionResult<PagedResult<Movie>>> GetMovies([FromQuery] Pagination pagination)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }

            var pagedResult = await _context.Movies.UsePageableAsync(pagination);
            return Ok(pagedResult);
        }

        // GET: api/Movies1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
          if (_context.Movies == null)
          {
              return NotFound();
          }
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
          if (_context.Movies == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
          }
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
