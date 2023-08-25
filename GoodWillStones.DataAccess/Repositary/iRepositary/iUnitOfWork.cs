using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWillStones.DataAccess.Repositary.iRepositary
{
    public interface iUnitOfWork
    {
        iCategoryRepositry Category{ get; }
        iProductRepositary Product { get; }
        void Save();
    }
}
