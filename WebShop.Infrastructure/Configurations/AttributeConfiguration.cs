using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Configurations
{
    public class AttributeConfiguration : IEntityTypeConfiguration<Domain.Entities.Attribute>
    {
        public void Configure (EntityTypeBuilder<Domain.Entities.Attribute> builder)
        {
            builder.ToTable("Attributes");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(a => a.AttributeType)
                   .WithMany(at => at.Attributes)
                   .HasForeignKey(a => a.TypeId);
        }
    }
}
