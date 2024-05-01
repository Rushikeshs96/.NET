using Microsoft.AspNetCore.Mvc;
using MVCDemo.DAL;
using MVCDemo.Migrations;

namespace MVCDemo.Controllers
{
    public class DemoDataController : Controller
    {
        private readonly EmployeeContext _context;

        public DemoDataController(EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data=_context.DemoDatas.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(demodata obj)
        {
            var data = _context.DemoDatas.Add(obj);
        }
    }
}
