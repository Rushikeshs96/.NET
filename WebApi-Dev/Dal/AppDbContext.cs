using Microsoft.EntityFrameworkCore;
using WebApi_Dev.Models;

namespace WebApi_Dev.Dal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Login>? logins { get; set; }
    }
}
