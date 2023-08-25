using GoodWillStones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWillStones.DataAccess.Repositary.iRepositary
{
    public interface iProductRepositary : iRepositary<Products>
    {
        void Update(Products obj);
        //void Save (); i have strated using unit of work so commenting this out 
    }
}
