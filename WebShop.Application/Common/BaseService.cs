using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Interfaces;
using WebShop.Domain.Exceptions;
using Mapster;
using FluentValidation;
using WebShop.Domain.Common;
using WebShop.Application.Common;

namespace WebShop.Application.Services
{
    public class BaseService<TEntity, TResponse> 
        (IRepository<TEntity> repository,
        IValidator<TEntity> validator)
        where TEntity : BaseEntity
    {
        protected IRepository<TEntity> repository = repository;

        public async Task<TResponse[]> GetAllAsync ()
        {
            TEntity[] entities = await repository.GetAllAsync();
            return entities.Adapt<TResponse[]>();
        }

        public async Task<TResponse> GetByIdAsync (Guid id)
        {
            TEntity entity = await repository.GetByIdAsync(id) ?? throw new NotFoundException();
            return entity.Adapt<TResponse>();
        }

        public async Task<TResponse[]> GetByAsync (Func<TEntity, bool> condition)
        {
            TEntity[] entities = await repository.GetByPredicate(condition);
            return entities.Adapt<TResponse[]>();
        }

        public async Task<TResponse> CreateAsync (IRequest request)
        {
            TEntity entity = request.Adapt<TEntity>();
            await validator.ValidateAndThrowAsync(entity);
            repository.Add(entity);
            await repository.SaveChangesAsync();
            return entity.Adapt<TResponse>();
        }

        public async Task<TResponse> UpdateAsync (IRequest request)
        {
            TEntity entity = request.Adapt<TEntity>();
            await validator.ValidateAndThrowAsync(entity);
            repository.Update(entity);
            await repository.SaveChangesAsync();
            return entity.Adapt<TResponse>();
        }

        public async Task<TResponse> RemoveById (Guid id)
        {
            TEntity entity = await repository.GetByIdAsync(id) ?? throw new NotFoundException();
            repository.Remove(entity);
            await repository.SaveChangesAsync();
            return entity.Adapt<TResponse>();
        }
    }
}
