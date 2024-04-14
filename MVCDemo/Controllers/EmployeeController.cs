using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
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
    }
}
