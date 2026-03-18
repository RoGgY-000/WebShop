using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
