using DOTNET_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
        [Authorize(Roles = "customer")] //only customer can accesee the getbook()
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            if (_jwtContext.Books == null)
            {
                return NotFound();
            }
            return await _jwtContext.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous] //anyone can accesee this
        public async Task<ActionResult<Book>> GetBook(int id)
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
            return book;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")] // Only admin role can accessthis belws method
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
        [Authorize(Roles = "admin")] // Only admin role can access this
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (_jwtContext.Books == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Book'  is null.");
            }
            _jwtContext.Books.Add(book);
            await _jwtContext.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")] 
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
