using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Interfaces
{
	public interface ICatalogRepository
	{
		Task<Category[]> GetCatalogAsync();
		Task<Category?> GetCategoryAsync (Guid id);
	}
}
