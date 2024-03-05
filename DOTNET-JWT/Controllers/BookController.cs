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
    }
}
