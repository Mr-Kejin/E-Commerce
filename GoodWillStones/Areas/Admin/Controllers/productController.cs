using GoodWillStones.DataAccess.Data;
using GoodWillStones.DataAccess.Repositary;
using GoodWillStones.DataAccess.Repositary.iRepositary;
using GoodWillStones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace GoodWillStones.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly iUnitOfWork _UnitOfWork; // insted of using the application db con we are suing a speciified method here using dependency iinjectiion

        public ProductController (iUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }



        public IActionResult Index()
        {
            List<Products> ObjProductList = _UnitOfWork.Product.GetAll().ToList();
            //var objProductList = _db.Categories.ToList(); // fetch data and show it in a list
           
            return View(ObjProductList); // passing the data to view 
        }
        public IActionResult CreateProduct()
        {
            // using projection we are doing it 
            // Populating the products drop down 
            IEnumerable<SelectListItem> CategoryList = _UnitOfWork.Category.GetAll().Select(x => new SelectListItem
            {
                Text = x.sDescription,
                Value = x.lCategory_ID.ToString()
            });
            ViewBag.categoryList = CategoryList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Products Obj)
        {

            if (ModelState.IsValid)
            {
                _UnitOfWork.Product.Add(Obj); // we are telling the entity fw to add this category to the entity table 
                _UnitOfWork.Save();
                //_ProductRepo.Save();
                TempData["Success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult EditProduct(int? ProductId)
        {
            if (ProductId == null || ProductId == 0)

            {
                return NotFound();
            }

            Products? productFromDb = _UnitOfWork.Product.Get(u => u.Product_ID == ProductId);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult EditProduct(Products Obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Product.Update(Obj); // we are telling the entity fw to add this category to the entity table 
                _UnitOfWork.Save();
                TempData["Success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        // Delete Product
        // view 
        public IActionResult DeleteProduct(int? ProductId) // since the parameters are same we cant use the same delete name below
        {
            Products? ProductsFromDb = _UnitOfWork.Product.Get(x => x.Product_ID == ProductId);

            if (ProductId == null || ProductId == 0)
            {
                return NotFound();
            }
            // Product ProductFromDb = _db.Categories.Find(categoryId); find will ony work on the primary key of the table. but first or default will work everytime 
          //  Products? ProductsFromDb = _UnitOfWork.Product.Get(x => x.Product_ID == ProductId);
            if (ProductsFromDb == null)
            {
                return NotFound();
            }
            return View(ProductsFromDb);
        }
        //delete Action
        [HttpPost, ActionName("DeleteProduct")]
        public IActionResult DeleteProductPost(int? ProductId)
        {
            Products? obj = _UnitOfWork.Product.Get(x => x.Product_ID == ProductId);
            //_db.Categories.Find(categoryId);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitOfWork.Product.Remove(obj);
            TempData["Success"] = "Product Deleted Successfully";
            _UnitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}