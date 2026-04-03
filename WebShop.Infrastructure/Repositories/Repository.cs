using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Infrastructure.Repositories
{
    public class Repository<T, TKey> (AppDbContext context) : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        public virtual async Task<T?> GetByIdAsync (TKey id) => await _dbSet.FindAsync(id);

        public virtual async Task<T[]> GetAllAsync () => await _dbSet.ToArrayAsync();

        public void Add (T entity) => _dbSet.Add(entity);

        public void Update (T entity) => _dbSet.Update(entity);

        public void Remove (T entity) => _dbSet.Remove(entity);

        public Task SaveChangesAsync() => context.SaveChangesAsync();
    }
}
