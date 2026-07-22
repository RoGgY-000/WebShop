using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class Order : BaseEntity
    {
        public required User User { get; set; }
        public Guid UserId { get; set; }
        public required OrderStatus Status { get; set; }
        public Guid StatusId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public List<OrderItem> Items { get; set; } = [];
    }
}
