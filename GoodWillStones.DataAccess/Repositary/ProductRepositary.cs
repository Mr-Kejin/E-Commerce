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
            _db.Products.Update(obj); // we we have to update only the category we are passing the categoty here 
        }
    }
}


