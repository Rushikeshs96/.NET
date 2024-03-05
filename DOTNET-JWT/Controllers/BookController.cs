using DOTNET_JWT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly dotnetjwtContext _jwtContext;

        public BookController(dotnetjwtContext jwtContext)
        {
            _jwtContext = jwtContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            if(_jwtContext.Books == null)
            {
                return NotFound();
            }
            return await _jwtContext.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (_jwtContext.Books == null)
            {
                return NotFound();
            }
            var movie = await _jwtContext.Books.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _jwtContext.Entry(book).State = EntityState.Modified;

            try
            {
                await _jwtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

       
        [HttpPost]
        public async Task<ActionResult<Book>> PostMovie(Book book)
        {
            if (_jwtContext.Books== null)
            {
                return Problem("Entity set 'ApplicationDbContext.Book'  is null.");
            }
            _jwtContext.Books.Add(book);
            await _jwtContext.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_jwtContext.Books == null)
            {
                return NotFound();
            }
            var book = await _jwtContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _jwtContext.Books.Remove(book);
            await _jwtContext.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return (_jwtContext.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
