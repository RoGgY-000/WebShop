using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public required decimal BasePrice { get; set; }     
    }
}
