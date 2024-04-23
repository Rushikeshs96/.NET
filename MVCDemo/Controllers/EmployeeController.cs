using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
            var emp = _context.Employees.Single(e=>e.Id==id);

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
            List<Employee> emp = _context.Employees.Include(e => e.Department).ToList();
            return View(emp);
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp=_context.Employees.Single(e=>e.Id== id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Single(e => e.Id == id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View(emp);
        }
    }
}
