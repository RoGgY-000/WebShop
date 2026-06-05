using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Mapster;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
	public class CatalogService
		(ICatalogRepository repository,
		CategoryValidator validator)
	{
		public async Task<CategoryResponse[]> GetCatalogAsync ()
		{
			Category[] categories = await repository.GetCatalogAsync();
			return categories.Adapt<CategoryResponse[]>();
		}

		public async Task<CategoryResponse> GetCategoryAsync (Guid id)
		{
			Category category = await repository.GetCategoryAsync(id);
			return category.Adapt<CategoryResponse>();
		}

		public async Task CreateCategoryAsync (CreateCategoryRequest request)
		{
			Category category = request.Adapt<Category>();
			await validator.ValidateAndThrowAsync(category);
			await repository.CreateCategory(category);
			repository.SaveChangesAsync();
		}
	}
}
