using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public Category? Category { get; set; }
        public required string Name { get; set; }
        public required Guid CategoryId { get; set; }
        public required decimal BasePrice { get; set; }
        //public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        //public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        //public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();       
    }
}
