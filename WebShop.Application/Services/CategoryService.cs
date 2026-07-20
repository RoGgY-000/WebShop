using System;
using System.Collections.Generic;
using System.Text;
using Mapster;
using WebShop.Application.DTO;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace WebShop.Application.Services
{
    public class CategoryService
        (IRepository<Category> repository,
        IValidator<Category> validator)
        : BaseService<Category, CategoryResponse>
        (repository, validator)
    {
        public async Task<CategoryResponse> CreateCategoryAsync (CreateCategoryRequest request)
        {
            Category category = request.Adapt<Category>();
            await validator.ValidateAndThrowAsync(category);
            repository.Add(category);
            await repository.SaveChangesAsync();
            return category.Adapt<CategoryResponse>();
        }
	}
}
