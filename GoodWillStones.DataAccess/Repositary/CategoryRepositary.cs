using GoodWillStones.DataAccess.Data;
using GoodWillStones.DataAccess.Repositary.iRepositary;
using GoodWillStones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoodWillStones.DataAccess.Repositary
{
    public class CategoryRepositary : Repositary<Category>, iCategoryRepositry // internal class ---> public

    {
        public ApplicationDbContext _db;
        public CategoryRepositary (ApplicationDbContext db)  :base(db)
        {
            _db = db;
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj); // we we have to update only the category we are passing the categoty here 
        }
    }
}
