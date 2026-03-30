using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class Branch : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public required string Name { get; set; }
        public required string Address { get; set; }
    }
}
