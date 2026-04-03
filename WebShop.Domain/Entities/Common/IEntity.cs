using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
