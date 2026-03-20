using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class Attribute : IEntity<int>
    {
        public int Id { get; set; }
        public required AttributeType AttributeType { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public required string Name { get; set; }
        public int TypeId { get; set; }
    }
}
