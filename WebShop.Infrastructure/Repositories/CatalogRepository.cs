using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Application.DTO;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;
using WebShop.Domain.Interfaces;

namespace WebShop.Infrastructure.Repositories
{
    public class CatalogRepository 
        (AppDbContext context) 
        : ICatalogRepository
    {
        public async Task<Category[]> GetCatalogAsync ()
        {
            Category[] categories = await context.Categories
                .Include(c => c.SubCategories)
                .AsNoTrackingWithIdentityResolution()
                .ToArrayAsync();
            Category[] root = categories
                .Where(c => c.ParentCategoryId == null)
                .ToArray();
            return root;
        }

		public async Task<Category?> GetCategoryAsync (Guid id)
        {
            Category? category = await context.Categories
                .AsNoTracking()
                .Include(c => c.SubCategories)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
			return category;
		}
	}
}
