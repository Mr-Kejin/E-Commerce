﻿using GoodWillStones.Data;
using GoodWillStones.Models;
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
            List<Category> ObjCategoryList = _db.Categories.ToList();
            //var objCategoryList = _db.Categories.ToList(); // fetch data and show it in a list
            return View(ObjCategoryList); // passing the data to view 
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory (Category Obj)
        {
            if (Obj.sDescription == Obj.sDisplayOrder.ToString())
            {
                ModelState.AddModelError("sDescription", "Display odder and name cant have same data.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(Obj); // we are telling the entity fw to add this category to the entity table 
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}