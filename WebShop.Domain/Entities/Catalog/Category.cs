using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class Category : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
        public string? Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
