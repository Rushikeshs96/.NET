using EmployeeApplication.Models;
using Microsoft.AspNetCore.Mvc;

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
            List<Emp> employees = _context.Emps.ToList();
            return View(employees); 
        }



        public IActionResult Create()
        {
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
                        obj.Photo= memoryStream.ToArray();
                    }
                }
                _context.Emps.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
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
            return View(EmpFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Emp obj,IFormFile photo )
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
