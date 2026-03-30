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
    public abstract class BaseService<TEntity, TKey, TResponse> 
        (IRepository<TEntity, TKey> repository, 
        IUnitOfWork unitOfWork)
        where TEntity : class, IEntity<TKey>
    {
        protected IRepository<TEntity,TKey> repository = repository;
        protected IUnitOfWork unitOfWork = unitOfWork;

        public async Task<TResponse> GetByIdAsync (TKey id)
        {
            TEntity entity = await repository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
            return entity.Adapt<TResponse>();
        }

        public async Task<TResponse> RemoveById (TKey id)
        {
            TEntity entity = await repository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
            repository.Remove(entity);
            return entity.Adapt<TResponse>();
        }

        public async Task<TResponse[]> GetAllAsync ()
        {
            TEntity[] entities = await repository.GetAllAsync();
            return entities.Adapt<TResponse[]>();
        }
    }
}
