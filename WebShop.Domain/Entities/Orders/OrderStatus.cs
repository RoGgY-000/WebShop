using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class OrderStatus : BaseEntity
    {
        public required string Name { get; set; }
        public List<Order> Orders { get; set; } = [];
    }
}
