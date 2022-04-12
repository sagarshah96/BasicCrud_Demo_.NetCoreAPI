using Product_Crud.ApplicationContext;
using Product_Crud.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Services
{
    public class ProductService : IProduct
    {
        private readonly _ApplicationContext _dbContext;

        public ProductService(_ApplicationContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _dbContext.Products.Select(x => new ProductModel
            {
                productName = x.ProductName,
                productDesc = x.ProductDesc,
                hsnCode = x.HSNCode,
                expDate = x.ExpDate.Value.ToString("dd-MM-yyyy"),
                price = x.Price,
                productID = x.ProductID,
                productLinks = _dbContext.ProductLinks.Where(z => z.ProductID == x.ProductID).Select(y => new ProductLinksModel
                {
                    links = y.Links
                }).ToList()
            }).ToList();
        }

        public ProductModel GetByID(int id)
        {
            return _dbContext.Products.Where(x => x.ProductID == id).Select(x => new ProductModel
            {
                productName = x.ProductName,
                productDesc = x.ProductDesc,
                hsnCode = x.HSNCode,
                expDate = x.ExpDate.Value.ToString("yyyy-MM-dd"),
                price = x.Price,
                productID = x.ProductID,
                productLinks = _dbContext.ProductLinks.Where(z => z.ProductID == x.ProductID).Select(y => new ProductLinksModel
                {
                    links = y.Links
                }).ToList()
            }).FirstOrDefault();
        }

        public int Add(ProductModel obj)
        {
            if (obj != null)
            {
                Product objProd = new Product();
                objProd.ProductName = obj.productName;
                objProd.ProductDesc = obj.productDesc;
                objProd.HSNCode = obj.hsnCode;
                objProd.ExpDate = Convert.ToDateTime(obj.expDate);
                objProd.Price = obj.price;
                _dbContext.Add(objProd);
                _dbContext.SaveChanges();
                return objProd.ProductID;
            }
            else
            {
                return 0;
            }
        }

        public int Update(ProductModel obj)
        {
            var objProd = _dbContext.Products.Where(x => x.ProductID == obj.productID).FirstOrDefault();
            if (objProd != null)
            {
                objProd.ProductName = obj.productName;
                objProd.ProductDesc = obj.productDesc;
                objProd.HSNCode = obj.hsnCode;
                objProd.ExpDate = Convert.ToDateTime(obj.expDate);
                objProd.Price = obj.price;
                _dbContext.Update(objProd);
                _dbContext.SaveChanges();
                return objProd.ProductID;
            }
            else
            {
                return 0;
            }
        }

        public bool Delete(int id)
        {
            var obj = _dbContext.Products.Find(id);
            if (obj != null)
            {
                _dbContext.Remove(obj);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

       
    }
}
