﻿using GoodWillStones.DataAccess.Data;
using GoodWillStones.DataAccess.Repositary.iRepositary;
using GoodWillStones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GoodWillStones.Controllers
{
    public class CategoryController : Controller
    {
        private readonly iCategoryRepositry _CategoryRepo; // insted of using the application db con we are suing a speciified method here using dependency iinjectiion

        public CategoryController(iCategoryRepositry db)
        {
            _CategoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> ObjCategoryList = _CategoryRepo.GetAll().ToList();
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
            if(Obj.sDescription == Obj.sDisplayOrder.ToString())
            {
                ModelState.AddModelError("sDescription", "The display order cant exactly match");
            }
            if (ModelState.IsValid)
            {
                _CategoryRepo.Add(Obj); // we are telling the entity fw to add this category to the entity table 
                _CategoryRepo.Save();
                //_CategoryRepo.Save();
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
            Category? CategoryFromDb = _CategoryRepo.Get(u=>u.lCategory_ID == categoryId);
                //_db.Categories.FirstOrDefault(u => u.lCategory_ID == categoryId);
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
                _CategoryRepo.Update(Obj); // we are telling the entity fw to add this category to the entity table 
                _CategoryRepo.Save();
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
            Category? CategoryFromDb = _CategoryRepo.Get(x=>x.lCategory_ID == categoryId);
                // Finding using the lamda expression _db.Categories.FirstOrDefault(u => u.lCategory_ID == categoryId);
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
            Category? obj = _CategoryRepo.Get(x=>x.lCategory_ID==categoryId);
                //_db.Categories.Find(categoryId);
            if (obj == null)
            {
                return NotFound();
            }
            _CategoryRepo.Remove(obj);
            TempData["Success"] = "Category Deleted Successfully";
            _CategoryRepo.Save();
            return RedirectToAction("Index");         
        }

    }
}