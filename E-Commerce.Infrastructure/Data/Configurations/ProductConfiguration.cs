using E_Commerce.Domain.Entities.ProductEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(500)");
            builder.Property(p => p.PictureUrl).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(P=>P.Brand).WithMany().HasForeignKey(P => P.BrandId);
            builder.HasOne(P => P.Type).WithMany().HasForeignKey(P => P.TypeId);


        }
    }
}
