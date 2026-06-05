using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Common;
using WebShop.Domain.Interfaces;

namespace WebShop.Infrastructure.Repositories
{
    public class Repository<T> (AppDbContext context) : IRepository<T> 
        where T : BaseEntity
    {
        protected readonly DbSet<T> dbSet = context.Set<T>();

        public virtual async Task<T?> GetByIdAsync (Guid id) => await dbSet.FindAsync(id);

        public virtual async Task<T[]> GetAllAsync () => await dbSet.ToArrayAsync();

        public virtual async Task<T[]> GetByPredicate (Func<T, bool> p) => dbSet.Where(p).ToArray();

        public void Add (T entity) => dbSet.Add(entity);

        public void Update (T entity) => dbSet.Update(entity);

        public void Remove (T entity) => dbSet.Remove(entity);

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();
    }
}
