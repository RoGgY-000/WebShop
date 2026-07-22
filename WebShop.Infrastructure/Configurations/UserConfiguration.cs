using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure (EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasMaxLength(255);

            builder.Property(u => u.FirstName)
                .HasMaxLength(255);

            builder.Property(u => u.LastName)
                .HasMaxLength(255);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(255);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.HasMany(u => u.Roles)
                   .WithMany(r => r.Users)
                   .UsingEntity(ur => ur.ToTable("UserRoles"));
        }
    }
}
