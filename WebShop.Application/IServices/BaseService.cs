using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Domain.Interfaces;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;

namespace WebShop.Application
{
    public abstract class BaseService<TEntity, TKey, TResponse>
        (IRepository<TEntity, TKey> repository,
        IUnitOfWork unitOfWork)
        where TEntity : class, IEntity<TKey>
    {
        public async Task<TResponse?> GetByIdAsync (TKey id, Func<TEntity, TResponse> mapper)
        {
            TEntity? entity = await repository.GetByIdAsync(id);
            return entity==null ? throw new EntityNotFoundException() : mapper(entity);
        }
    }
}
