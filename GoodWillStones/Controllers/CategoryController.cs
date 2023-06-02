using GoodWillStones.DataAccess.Data;
using GoodWillStones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            List<Category> ObjCategoryList = _db.Categories.ToList();
            //var objCategoryList = _db.Categories.ToList(); // fetch data and show it in a list
            return View(ObjCategoryList); // passing the data to view 
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category Obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Add(Obj); // we are telling the entity fw to add this category to the entity table 
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult EditCategory(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            // Category CategoryFromDb = _db.Categories.Find(categoryId); find will ony work on the primary key of the table. but first or default will work everytime 
            Category? CategoryFromDb = _db.Categories.FirstOrDefault(u => u.lCategory_ID == categoryId);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
        public IActionResult EditCategory(Category Obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Obj); // we are telling the entity fw to add this category to the entity table 
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        // Delete Category
        // view 
        public IActionResult DeleteCategory(int? categoryId) // since the parameters are same we cant use the same delete name below
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            // Category CategoryFromDb = _db.Categories.Find(categoryId); find will ony work on the primary key of the table. but first or default will work everytime 
            Category? CategoryFromDb = _db.Categories.FirstOrDefault(u => u.lCategory_ID == categoryId);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        //delete Action
        [HttpPost, ActionName ("DeleteCategory")]
        public IActionResult DeleteCategoryPost (int? categoryId)
        {
            Category? obj = _db.Categories.Find(categoryId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            TempData["Success"] = "Category Deleted Successfully";
            _db.SaveChanges();
            return RedirectToAction("Index");         
        }

    }
}