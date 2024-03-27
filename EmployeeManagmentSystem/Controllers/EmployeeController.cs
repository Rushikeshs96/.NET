using EmployeeManagmentSystem.DAL;
using EmployeeManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Controllers
{
    public class EmployeeController : Controller
    {
       private readonly ApplicationDbContext _context;

       public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //get
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        //get by id
        public async Task<IActionResult> Details(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
            if(employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            // Pass a list of departments for the dropdown in the view
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //edit
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(m=>m.Id==id);
            if(employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
           
            if (ModelState.IsValid)
            {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");

            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee= await _context.Employees.FirstOrDefaultAsync(m=>m.Id== id);   
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
    }
}
