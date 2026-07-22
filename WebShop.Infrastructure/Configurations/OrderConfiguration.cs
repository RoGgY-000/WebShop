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
            builder.HasKey(o => o.Id);

            builder.Property(o => o.DateTimeCreated)
                   .IsRequired();

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId);

            builder.HasOne(o => o.Status)
                   .WithMany(s => s.Orders)
                   .HasForeignKey(o => o.StatusId);
        }
    }
}
