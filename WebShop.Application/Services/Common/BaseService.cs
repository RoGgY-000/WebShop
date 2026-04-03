using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Domain.Interfaces;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;
using Mapster;
using FluentValidation;

namespace WebShop.Application.Services
{
    public class BaseService<TEntity, TKey, TResponse> 
        (IRepository<TEntity, TKey> repository,
        IValidator<TEntity> validator)
        where TEntity : BaseEntity<TKey>
    {
        protected IRepository<TEntity,TKey> repository = repository;
        public async Task<TResponse[]> GetAllAsync ()
        {
            TEntity[] entities = await repository.GetAllAsync();
            return entities.Adapt<TResponse[]>();
        }

        public async Task<TResponse> GetByIdAsync (TKey id)
        {
            TEntity entity = await repository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
            return entity.Adapt<TResponse>();
        }

        public async Task<TResponse> Create (IRequest request)
        {
            TEntity entity = request.Adapt<TEntity>();
            await validator.ValidateAndThrowAsync(entity);
            repository.Add(entity);
            await repository.SaveChangesAsync();
            return entity.Adapt<TResponse>();
        }

        public async Task<TResponse> Update (IRequest request)
        {
            TEntity entity = request.Adapt<TEntity>();
            await validator.ValidateAndThrowAsync(entity);
            repository.Update(entity);
            await repository.SaveChangesAsync();
            return entity.Adapt<TResponse>();
        }

        public async Task<TResponse> RemoveById (TKey id)
        {
            TEntity entity = await repository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
            repository.Remove(entity);
            await repository.SaveChangesAsync();
            return entity.Adapt<TResponse>();
        }

    }
}
