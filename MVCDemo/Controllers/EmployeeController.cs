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
            Employee emp = new()
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

            var emp = _context.Employees?.SingleOrDefault(e => e.Id == id);

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

        public IActionResult EmployeeList(String searchBy, String search)
        {

            if (searchBy == "Gender")
            {
                return View(_context.Employees?.Where(x => x.Gender == search || search == null).Include(e => e.Department).ToList());
            }
            else if (searchBy == "DepartmentName")
            {
                return View(_context.Employees?.Where(x => x.Department.Name == search || search == null).Include(e => e.Department).ToList());

            }
            else
            {
                return View(_context.Employees?.Where(x => x.Name.StartsWith(search) || search == null).Include(e => e.Department).ToList());
            }
        }

        public IActionResult Indexfmd()
        {

          var data=_context.Employees.ToList();
            return View(data);  
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
                _context?.Employees?.Add(emp);
                _context?.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = _context.Employees?.Single(e => e.Id == id);
            return View(emp);

        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees?.Update(emp);
                _context.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees?.Single(e => e.Id == id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees?.Remove(emp);
                _context.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View(emp);

        }

        [HttpPost]
        public IActionResult DeleteMultiple(IEnumerable<int> employeeToDelete)
        {
            var employeesToDelete = _context.Employees?.Where(e => employeeToDelete.Contains(e.Id)).ToList();
            _context.Employees?.RemoveRange(employeesToDelete);
            _context.SaveChanges();
            return RedirectToAction("Indexfmd");
        }

        public IActionResult EmployeesByDepartment()
        {
            var employees = _context.Employees?.Include("Department")
                          .GroupBy(x => x.Department.Name)
                          .Select(y => new DepartmentTotals
                          {
                              Name = y.Key,
                              Total = y.Count()
                          }).ToList();
            return View(employees);
        }
    }
}
