using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Configurations
{
    public class AttributeTypeConfiguration : IEntityTypeConfiguration<AttributeType>
    {
        public void Configure (EntityTypeBuilder<AttributeType> builder)
        {
            builder.ToTable("AttributeTypes");
            builder.HasKey(at => at.Id);

            builder.Property(at => at.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
