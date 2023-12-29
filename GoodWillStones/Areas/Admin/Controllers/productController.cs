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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(iUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = UnitOfWork;
            _webHostEnvironment = webHostEnvironment;
        } 



        public IActionResult Index()
        {
            List<Products> ObjProductList = _UnitOfWork.Product.GetAll(includeProperties: "Category").ToList();
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
        public IActionResult UpsertProduct(ProductVm productVm,IFormFile file) // ref 92
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // assignining a proper name to the uploaded image 
                    string productPath = Path.Combine(wwwRootPath, @"Images\Products");

                    if (!string.IsNullOrEmpty(productVm.Products.ImageURL)) // replcing image handled here
                    { // if image is present we need to remove te old imag and add nw 
                        var oldImmagePath = Path.Combine(wwwRootPath , productVm.Products.ImageURL.TrimStart('\\'));
                       if (System.IO.File.Exists(oldImmagePath))
                        {
                            System.IO.File.Delete(oldImmagePath);
                        }
                    }

                    using( var fileStream = new FileStream(Path.Combine(productPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream); 
                    }

                    productVm.Products.ImageURL = @"\Images\Products\" + fileName;
                }
                if (productVm.Products.Product_ID == 0)
                {
                    _UnitOfWork.Product.Add(productVm.Products); 
                }
                else
                {
                    _UnitOfWork.Product.Update(productVm.Products);
                }
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
        
        // Delete Product
        // view 
        public IActionResult DeleteProduct(int? ProductId) // since the parameters are same we cant use the same delete name below
        {
            Products? ProductsFromDb = _UnitOfWork.Product.Get(x => x.Product_ID == ProductId);

            if (ProductId == null || ProductId == 0)
            {
                return NotFound();
            }
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

        //#region API CALLS
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<Products> ObjProductList = _UnitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        //    return Json(new {data = ObjProductList});
        //}

        //#endregion

    }
}