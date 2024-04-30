using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDemo.DAL;
using MVCDemo.Models;
using System.Diagnostics;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeContext _context;

        public HomeController(EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Country = new List<String>()     //viewbag uses dynamic properties. internally viewbag properties are stores as name/value pair in viewdata disctionery.
            {
                "India",
                "China",
                "Japan",
                "Korea"
            };

            ViewData["City"] = new List<String>()     //uses string keys. viewdata is dictionery of objects
            {
                "Pune",
                "Mumbau",
                "Delhie",
                "satara"
            };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HtmlHelpers()
        {
            ViewBag.departments = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }
    }
}