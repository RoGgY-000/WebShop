using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Mapster;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
	public class CatalogService
		(ICatalogRepository repository)
	{
		public async Task<CategoryResponse[]> GetCatalogAsync ()
		{
			Category[] categories = await repository.GetCatalogAsync();
			return categories.Adapt<CategoryResponse[]>();
		}

		public async Task<CategoryResponse> GetCategoryAsync (Guid id)
		{
			Category category = await repository.GetCategoryAsync(id) 
				?? throw new NotFoundException("Категория не найдена.");
			return category.Adapt<CategoryResponse>();
		}
	}
}
