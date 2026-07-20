using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure (EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired(false);

            //builder.HasMany(c => c.Attributes)
            //       .WithMany(a => a.Categories)
            //       .UsingEntity(ca => ca.ToTable("CategoryAttributes"));
        }
    }
}
