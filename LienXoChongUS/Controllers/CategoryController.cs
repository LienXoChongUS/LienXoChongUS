using LienXoChongUS.Data;
using LienXoChongUS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LienXoChongUS.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
    }
}
