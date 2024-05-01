using Microsoft.AspNetCore.Mvc;
using MVCDemo.DAL;

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
    }
}
