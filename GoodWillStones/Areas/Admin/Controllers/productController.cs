using GoodWillStones.DataAccess.Data;
using GoodWillStones.DataAccess.Repositary;
using GoodWillStones.DataAccess.Repositary.iRepositary;
using GoodWillStones.Models;
using GoodWillStones.Models.ViewModels;
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
            return View(ObjProductList); // passing the data to view 
        }
        public IActionResult UpsertProduct(int? ProductID)
        {
            ProductVm productVm = new()
            {
                CategoryList = _UnitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.sDescription,
                    Value = x.lCategory_ID.ToString(),
                }),
                Products = new Products()
            };
            if(ProductID == null || ProductID == 0) // crating a new record 
            {
                return View(productVm);
            }
            else  // Updating existing record 
            {
                productVm.Products = _UnitOfWork.Product.Get(x=>x.Product_ID== ProductID);
                return View(productVm);
            }
        }

        [HttpPost]
        public IActionResult UpsertProduct(ProductVm productVm,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                _UnitOfWork.Product.Add(productVm.Products); // we are telling the entity fw to add this category to the entity table 
                _UnitOfWork.Save();
                TempData["Success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
             else
            {
                productVm.CategoryList = _UnitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.sDescription,
                    Value = x.lCategory_ID.ToString(),
                });
                return View(productVm);
            }
            
        }
        //public IActionResult EditProduct(int? ProductId, IFormFile file)
        //{


        //    if (ProductId == null || ProductId == 0)

        //    {
        //        return NotFound();
        //    }
            
        //    Products? productFromDb = _UnitOfWork.Product.Get(u => u.Product_ID == ProductId);

        //    if (productFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productFromDb);
        //}
        //[HttpPost]
        //public IActionResult EditProduct(Products Obj)  // (ProductsVm productVm, file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _UnitOfWork.Product.Update(Obj); // we are telling the entity fw to add this category to the entity table 
        //        _UnitOfWork.Save();
        //        TempData["Success"] = "Product Updated Successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
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