using DOTNET_JWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DOTNET_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly dotnetjwtContext _jwtContext;
        private readonly IConfiguration _configuration;

        public AuthController(dotnetjwtContext jwtContext, IConfiguration configuration)
        {
            _jwtContext = jwtContext;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Login login)
        {
            // Your authentication logic here
            var user = await _jwtContext.Logins.FirstOrDefaultAsync(u => u.LoginId == login.LoginId && u.Password == login.Password);

            if (user != null)
            {
                // Authentication successful, generate JWT token
                var token = GenerateJwtToken(user.Id.ToString(), user.Role);
                return Ok(new { token });
            }
            else
            {
                // Authentication failed
                return Unauthorized();
            }
        }

        private string GenerateJwtToken(string userId, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, role)
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
