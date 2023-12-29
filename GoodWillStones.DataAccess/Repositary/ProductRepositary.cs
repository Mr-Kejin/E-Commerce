using GoodWillStones.DataAccess.Data;
using GoodWillStones.DataAccess.Repositary.iRepositary;
using GoodWillStones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWillStones.DataAccess.Repositary
{
    public class ProductRepositary : Repositary<Products>, iProductRepositary // internal class ---> public

    {
        public ApplicationDbContext _db;
        public ProductRepositary(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Products obj)
        {
           // _db.Products.Update(obj); // we we have to update only the category we are passing the categoty here 
            var objFromDb = _db.Products.FirstOrDefault(x => x.Product_ID == obj.Product_ID);  
            if (objFromDb != null)
            {
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.ListPrice100 = obj.ListPrice100;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;   
                objFromDb.Product_ID = obj.Product_ID;
                objFromDb.sDescription = obj.sDescription;
                objFromDb.Category = obj.Category;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.sProductName = obj.sProductName;
                if(obj.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }
            }
        }
    }
}


