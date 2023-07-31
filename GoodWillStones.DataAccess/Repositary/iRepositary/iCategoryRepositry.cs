using GoodWillStones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoodWillStones.DataAccess.Repositary.iRepositary
{
    public interface iCategoryRepositry : iRepositary<Category>
    {
        void Update(Category obj);
        //void Save (); i have strated using unit oof work so commenting this out 
    }
}
