using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class AttributeType
    {
        public int Id { get; private set; }
        public ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
        public required string Name { get; set; }
    }
}
