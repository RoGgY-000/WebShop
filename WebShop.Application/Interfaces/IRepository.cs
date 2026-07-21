using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Common;

namespace WebShop.Domain.Interfaces
{
    public interface IRepository<T> 
        where T : BaseEntity
    {
        Task<T?> GetByIdForReadAsync (Guid id);
        Task<T?> GetByIdForUpdateAsync (Guid id);
        Task<T[]> GetByPredicate (Func<T, bool> p);
		Task<T[]> GetAllAsync ();
        void Add (T entity);
        void Update (T entity);
        void Remove (T entity);
        Task SaveChangesAsync ();
    }
}
