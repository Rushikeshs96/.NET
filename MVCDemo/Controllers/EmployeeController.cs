using Microsoft.AspNetCore.Mvc;
using MVCDemo.DAL;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Employee emp = new Employee()
            {
                Id = 1,
                Name = "rushi",
                Gender = "male",
                City = "asu"
            };

            return View(emp);
        }

        public ActionResult Details(int id)
        {
            var emp= _context.Employees.FirstOrDefault(s=>s.Id==id);
            return View(emp);
        }
    }
}
