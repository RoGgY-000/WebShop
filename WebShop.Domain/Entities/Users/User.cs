using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class User : BaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Passwordhash { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
