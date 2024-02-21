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
    }
}
