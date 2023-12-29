using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GoodWillStones.DataAccess.Data;
using GoodWillStones.DataAccess.Repositary.iRepositary;
using Microsoft.EntityFrameworkCore;

namespace GoodWillStones.DataAccess.Repositary
{
    public class Repositary<T> : iRepositary<T> where T : class
    {
        public readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        public Repositary(ApplicationDbContext db) 
        { 
            _db = db;
            this.dbset = _db.Set<T>(); // data has been inherited 
                                       // _db.Categories == dbset 
            _db.Products.Include(x => x.Category).Include(x=> x.CategoryId);
           
        }

        public void Add(T entity)
        {
            dbset.Add(entity);

        }
     

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> Filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(Filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault(); 
        }

        //
        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public void Remove (T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
