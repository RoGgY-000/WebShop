using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Dictionary<string,object?> Attributes { get; set; } = new Dictionary<string, object?>();        
        public required string Name { get; set; }
        public required int CategoryId { get; set; }
        public decimal BasePrice { get; set; }
    }
}
