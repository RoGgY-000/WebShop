using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Common;
using WebShop.Domain.Interfaces;

namespace WebShop.Infrastructure.Repositories
{
    public class Repository<T> (AppDbContext context) : IRepository<T> 
        where T : BaseEntity
    {
        protected readonly DbSet<T> dbSet = context.Set<T>();

        public virtual async Task<T?> GetByIdForReadAsync (Guid id) 
            => await dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        public virtual async Task<T?> GetByIdForUpdateAsync (Guid id)
            => await dbSet.FindAsync(id);

        public virtual async Task<T[]> GetAllAsync () 
            => await dbSet
            .AsNoTracking()
            .ToArrayAsync();

        public virtual async Task<T[]> GetByPredicate (Func<T, bool> p) 
            => dbSet
            .AsNoTracking()
            .Where(p)
            .ToArray();

        public void Add (T entity) => dbSet.Add(entity);

        public void Update (T entity) => dbSet.Update(entity);

        public void Remove (T entity) => dbSet.Remove(entity);

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();
    }
}
