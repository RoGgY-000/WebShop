using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class OrderStatus : IEntity<int>
    {
        public int Id { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public required string Name { get; set; }
    }
}
