using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class AttributeType : BaseEntity<int>
    {
        public int Id { get; set; }
        public ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
        public required string Name { get; set; }
    }
}
