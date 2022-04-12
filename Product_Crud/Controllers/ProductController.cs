using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Crud.ApplicationContext;
using Product_Crud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly IProductLink _productlink;

        public ProductController(IProduct obj, IProductLink lnk)
        {
            _product = obj;
            _productlink = lnk;
        }

        [HttpPost]
        public IActionResult Save(ProductModel objProduct)
        {
            Response obj = new Response();
            try
            {
                int id = _product.Add(objProduct);
                foreach (var item in objProduct.productLinks)
                {
                    int id1 = _productlink.Add(item.links, id);
                }

                obj.StatusCode = 1;
                obj.Messgae = "Successfully Added.";

            }
            catch (Exception ex)
            {
                obj.StatusCode = 0;
                obj.Messgae = ex.ToString();
            }
            return Json(obj);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            IEnumerable<ProductModel> lstProduct = null;
            //Response obj = new Response();
            try
            {
                lstProduct = _product.GetAll();
            }
            catch (Exception ex)
            {
                //lstProduct.StatusCode = 0;
                //lstProduct.Messgae = ex.ToString();
            }
            return Json(lstProduct);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductsByID(int id)
        {
            ProductModel objProduct = null;
            try
            {
                objProduct = _product.GetByID(id);
                objProduct.StatusCode = 1;
            }
            catch (Exception ex)
            {
                objProduct.StatusCode = 0;
                objProduct.Messgae = ex.ToString();
            }
            return Json(objProduct);
        }

        [HttpPut]
        public IActionResult Update(ProductModel objProduct)
        {
            Response obj = new Response();
            try
            {
                int id = _product.Update(objProduct);
                bool res = _productlink.Delete(id);
                foreach (var item in objProduct.productLinks)
                {
                    int id1 = _productlink.Add(item.links, id);
                }

                obj.StatusCode = 1;
                obj.Messgae = "Successfully Updated.";

            }
            catch (Exception ex)
            {
                obj.StatusCode = 0;
                obj.Messgae = ex.ToString();
            }

            return Json(obj);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response obj = new Response();
            try
            {
                _productlink.Delete(id);
                _product.Delete(id);

                obj.StatusCode = 1;
                obj.Messgae = "Successfully Deleted.";
            }
            catch (Exception ex)
            {
                obj.StatusCode = 0;
                obj.Messgae = ex.ToString();
            }
            return Json(obj);
        }
    }
}
