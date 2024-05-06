using Microsoft.AspNetCore.Mvc;
using MVCDemo.DAL;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly EmployeeContext _context;

        public DepartmentController(EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Department> list = _context.Departments.ToList();
            return View(list);
        }
    }
}
