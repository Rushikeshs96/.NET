using EmployeeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApplication.Controllers
{
    public class EmpController : Controller
    {
        private readonly employeeContext _context;

        public EmpController(employeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employee = _context.Emps.Include(e => e.State).Include(e => e.State.Cities).ToList();
            return View(employee);
        }



        public IActionResult Create()
        {
           ViewBag.States = new SelectList (_context.States, "StateId","StateName");
           ViewBag.Cities = new SelectList(new List<City>(), "CityId", "CityName"); // Empty list initially

            return View();
        }

        [HttpPost]
        public IActionResult Create(Emp obj, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        photo.CopyTo(memoryStream);
                        obj.Photo = memoryStream.ToArray();
                    }
                }

                
                _context.Emps.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.States = new SelectList(_context.States, "StateId", "StateName");
            return View();
        }


       



        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Emp? EmpFromDb = _context.Emps.FirstOrDefault(c => c.Id == id); ;


            if (EmpFromDb == null)
            {
                return NotFound();
            }
            ViewBag.States = new SelectList(_context.States, "StateId", "StateName");
            return View(EmpFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Emp obj, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        photo.CopyTo(memoryStream);
                        obj.Photo = memoryStream.ToArray();
                    }
                }
                _context.Emps.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.States = new SelectList(_context.States, "StateId", "StateName");
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Emp? EmpFromDb = _context.Emps.FirstOrDefault(c => c.Id == id);
            if (EmpFromDb == null)
            {
                return NotFound();
            }
            return View(EmpFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Emp obj = _context.Emps.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Emps.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}