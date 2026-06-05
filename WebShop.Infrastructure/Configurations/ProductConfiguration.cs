using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure (EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(p => p.BasePrice)
                   .IsRequired();

            //builder.Property(p => p.Attributes)
            //       .HasColumnType("jsonb");

            //builder.HasIndex(p => p.Attributes)
            //       .HasMethod("gin");

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);
        }
    }
}
