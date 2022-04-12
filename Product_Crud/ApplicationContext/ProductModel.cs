using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.ApplicationContext
{
    public class ProductModel : Response
    {
       
        public int productID { get; set; }

        public string productName { get; set; }

        public string productDesc { get; set; }

        public string hsnCode { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string expDate { get; set; }

        public decimal? price { get; set; }

        public List<ProductLinksModel> productLinks { get; set; }

        public ProductModel()
        {
        }

    }

    public class ProductLinksModel
    {
        public string links { get; set; }

    }
}
