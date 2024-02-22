using BookManagment.Data;
using BookManagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagment.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategorylist = _db.categories.ToList();
            return View(objCategorylist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int id) //the is passed from view as asp-route-id="@obj.Id"
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category ? categoryFromDb = _db.categories.FirstOrDefault(c => c.Id == id); ;
            // above or belows options works same
           // Category ?  categoryFromDb = _db.categories.Find(id);
          //  Category ? categoryFromDb = _db.categories.Where(u=>u.Id == id).FirstOrDefault(); 

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
