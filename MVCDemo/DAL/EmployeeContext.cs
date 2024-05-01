using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;

namespace MVCDemo.DAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            
        }

        public DbSet<Employee>? Employees { get; set; }

        public DbSet<Department>? Departments { get; set; }

        public DbSet<DemoData>? DemoDatas { get; set; }
    }
}
