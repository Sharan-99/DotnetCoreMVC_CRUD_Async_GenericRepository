using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreMVC_CRUD_Async_GenericRepository.Models
{
    public class ProductsDbContext:DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
