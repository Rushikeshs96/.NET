using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Dev.Dal;
using WebApi_Dev.Models;

namespace WebApi_Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("register")]
        public ActionResult<Login> Register(Login reg)
        {
            if (reg == null)
            {
                return BadRequest("Invalid data provided.");
            }
           
            _context.logins.Add(reg);
        
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult<Login> Login(Login login)
        {
            var obj = _context.logins.FirstOrDefault(x => x.Uid == login.Uid && x.Password == login.Password);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
    }
}
