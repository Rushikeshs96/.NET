using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCDemo.DAL;
using MVCDemo.Migrations;
using MVCDemo.Models;

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
            var data = _context.DemoDatas?.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DemoData data)
        {
            if (ModelState.IsValid)
            {
                _context.DemoDatas?.Add(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _context.DemoDatas?.Single(e => e.Id == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(DemoData data)
        {
            if (ModelState.IsValid)
            {
                _context.DemoDatas?.Update(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.DemoDatas?.Single(e => e.Id == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(DemoData data)
        {
            if (ModelState.IsValid)
            {
                _context.DemoDatas?.Remove(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _context.DemoDatas?.Single(e => e.Id == id);
            return View(data);
        }
    }
}
