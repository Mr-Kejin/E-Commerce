using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoodWillStones.DataAccess.Repositary.iRepositary
{
    public interface iRepositary<T> where T : class
    {
        // T - category or any other generic model
        //here im using it gor generic method 
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> Filter); // link operation general syntax
        // t= type  and dat type will be bool
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange (IEnumerable<T> entity);
        // since update cant be generic we are not having it in the gentric class

    }

}
