using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
   public class ProductDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    }
}
