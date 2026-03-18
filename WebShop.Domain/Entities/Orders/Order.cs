using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class Order
    {
        public Guid Id { get; set; }
        public required User User { get; set; }
        public required Branch Branch { get; set; }
        public required OrderStatus Status { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Guid UserId { get; set; }
        public int BranchId { get; set; }
        public int StatusId { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
