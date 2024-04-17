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
            var emp = _context.Employees?.Single(s => s.Id == id);
            return View(emp);
        }

        public IActionResult IndexAction()
        {
            List<Employee>? list = _context.Employees?.ToList();
            return View(list);
        }

        public IActionResult IndexForDept(int departmentId)
        {
            List<Employee>? list = _context.Employees?.Where(s => s.DepartmentId == departmentId).ToList();
            return View(list);
        }

        public IActionResult EmployeeList()
        {
            var list = _context.Employees?.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult Create_Post(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View();
        }
    }
}
