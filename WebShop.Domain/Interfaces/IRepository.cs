using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Interfaces
{
    public interface IRepository<T,TKey> where T : BaseEntity<TKey>
    {
        Task<T?> GetByIdAsync (TKey id);
        Task<T[]> GetAllAsync ();
        void Add (T entity);
        void Update (T entity);
        void Remove (T entity);
        Task SaveChangesAsync ();
    }
}
