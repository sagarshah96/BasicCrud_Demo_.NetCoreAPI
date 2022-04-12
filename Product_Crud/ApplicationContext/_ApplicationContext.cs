using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_Crud.DBContext;

namespace Product_Crud.ApplicationContext
{
    public class _ApplicationContext : DbContext
    {
        public _ApplicationContext(DbContextOptions<_ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLinks> ProductLinks { get; set; }

    }
}
