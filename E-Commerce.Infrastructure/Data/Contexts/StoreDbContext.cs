using E_Commerce.Domain.Entities.ProductEntities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.Data.Contexts
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } 
        public DbSet<ProductBrand> ProductBrands { get; set; } 
        public DbSet<ProductType> ProductTypes { get; set; } 
        public StoreDbContext(DbContextOptions<StoreDbContext> options ): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }
    }
}
