using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class Stock
    {
        public Guid ProductId { get; set; }
        public int BranchId { get; set; }
        public required Product Product { get; set; }
        public required Branch Branch { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
