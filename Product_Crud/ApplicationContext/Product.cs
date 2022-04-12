using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.DBContext
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [MaxLength(100)]
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDesc { get; set; }

        [MaxLength(20)]
        public string HSNCode { get; set; }

        //[DataType(DataType.Date)] 
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ExpDate { get; set; }

        public decimal? Price { get; set; }

    }
}
