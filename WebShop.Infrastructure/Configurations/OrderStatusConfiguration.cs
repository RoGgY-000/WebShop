using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure (EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatuses");
            builder.HasKey(os => os.Id);

            builder.Property(os => os.Name)
                   .IsRequired();
        }
    }
}
