using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class OrderStatus : BaseEntity
    {
        public int Id { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public required string Name { get; set; }
    }
}
