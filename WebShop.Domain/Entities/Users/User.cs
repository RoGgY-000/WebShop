using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public List<Order> Orders { get; set; } = [];
        public List<Role> Roles { get; set; } = [];
    }
}
