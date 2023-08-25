using GoodWillStones.DataAccess.Data;
using GoodWillStones.DataAccess.Repositary.iRepositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWillStones.DataAccess.Repositary
{
    public class UnitOfWork : iUnitOfWork
    {
        //Application db context using dependency injection
        public ApplicationDbContext _db;
        public iCategoryRepositry Category { get; private set; }
        public iProductRepositary Product { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepositary(_db);
            Product = new ProductRepositary(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
