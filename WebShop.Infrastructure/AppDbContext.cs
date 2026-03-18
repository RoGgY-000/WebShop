using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Domain.Entities.Attribute> Attributes => Set<Domain.Entities.Attribute>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();
        public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
        public DbSet<AttributeType> AttributeTypes => Set<AttributeType>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
