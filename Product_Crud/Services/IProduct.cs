using Product_Crud.ApplicationContext;
using Product_Crud.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Services
{
    public interface IProduct
    {
        int Add(ProductModel obj);

        int Update(ProductModel obj);

        bool Delete(int id);

        IEnumerable<ProductModel> GetAll();

        ProductModel GetByID(int id);
    }
}
