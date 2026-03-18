using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure (EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");
            builder.HasKey(s => new {s.ProductId, s.BranchId});

            builder.Property(s => s.Price)
                .IsRequired();

            builder.Property(s => s.Quantity)
                .IsRequired();

            builder.HasOne(s => s.Branch)
                   .WithMany(b => b.Stocks)
                   .HasForeignKey(s => s.BranchId);

            builder.HasOne(s => s.Product)
                   .WithMany(p => p.Stocks)
                   .HasForeignKey(s => s.ProductId);
        }
    }
}
