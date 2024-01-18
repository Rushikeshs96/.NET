using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dot_Net_WebApi.Models;
using Microsoft.AspNetCore.Connections;

namespace Dot_Net_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DefaultConnectionContext _dbContext;

        public MoviesController(DefaultConnectionContext dbcontext)
        {
            _dbContext = dbcontext;
        }


    }
}
