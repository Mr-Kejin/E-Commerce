using GoodWillStones.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoodWillStones.Controllers
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
            var objCategoryList = _db.Categories.ToList(); // fetch data and show it in a list
            return View();
        }
    }
}
