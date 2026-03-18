using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure (EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(os => os.Id);

            builder.Property(os => os.DateTimeCreated)
                   .IsRequired();

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId);

            builder.HasOne(o => o.Branch)
                   .WithMany(b => b.Orders)
                   .HasForeignKey(o => o.BranchId);

            builder.HasOne(o => o.Status)
                   .WithMany(s => s.Orders)
                   .HasForeignKey(o => o.StatusId);
        }
    }
}
