using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.DBContext
{
    public class ProductLinks
    {
        [Key]
        public int LinksID { get; set; }
        [Required]
        public string Links { get; set; }

        public int ProductID { get; set; }

    }
}
