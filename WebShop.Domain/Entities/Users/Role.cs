using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class Role : BaseEntity
    {
        public required string Name { get; set; }
        public List<User> Users { get; set; } = [];
    }
}
