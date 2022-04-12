using Product_Crud.ApplicationContext;
using Product_Crud.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Services
{
    public interface IProductLink
    {
        int Add(string links, int id);

        bool Delete(int id);

       
    }
}
