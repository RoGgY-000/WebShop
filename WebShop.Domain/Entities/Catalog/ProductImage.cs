using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public sealed class ProductImage : BaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public required Product Product { get; set; }
        public required string FilePath { get; set; }
        public Guid ProductId { get; set; }
        public int SortingIndex { get; set; }
    }
}
