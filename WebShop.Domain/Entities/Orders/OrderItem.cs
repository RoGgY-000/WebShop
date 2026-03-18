using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class OrderItem
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public required Order Order { get; set; }
        public required Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
