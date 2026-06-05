using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class Role : BaseEntity
    {
        public Guid Id { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public required string Name { get; set; }
    }
}
