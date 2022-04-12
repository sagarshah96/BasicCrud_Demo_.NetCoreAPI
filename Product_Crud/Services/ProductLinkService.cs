using Product_Crud.ApplicationContext;
using Product_Crud.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Services
{
    public class ProductLinkService : IProductLink
    {
        private readonly _ApplicationContext _dbContext;

        public ProductLinkService(_ApplicationContext context)
        {
            _dbContext = context;
        }

        public int Add(string links, int id)
        {
            if (id > 0)
            {
                ProductLinks objProd = new ProductLinks();
                objProd.Links = links;
                objProd.ProductID = id;
                _dbContext.ProductLinks.Add(objProd);
                _dbContext.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public bool Delete(int id)
        {
            var obj = _dbContext.ProductLinks.Where(x=>x.ProductID == id).ToList();
            if (obj != null)
            {
                _dbContext.RemoveRange(obj);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
