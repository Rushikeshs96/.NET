using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDemo.Models;
using System.Diagnostics;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            ViewBag.Country = new List<String>()
            {
                "India",
                "China",
                "Japan",
                "Korea"
            };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}