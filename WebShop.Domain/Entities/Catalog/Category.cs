using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public string? Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        //public ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
    }
}
