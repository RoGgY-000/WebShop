using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;

namespace WebShop.Infrastructure.Repositories
{
    public class CategoryRepository (AppDbContext context) : Repository<Category,Guid>(context)
    {
        public override async Task<Category?> GetByIdAsync (Guid id)
        {
            Category category = await context.Categories
            .Include(c => c.SubCategories)
            .Include(c => c.Products)
            .Include(c => c.ParentCategory)
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new EntityNotFoundException();

            Product[] products = await context.Products
                .Where(p => p.CategoryId == id)
                .OrderBy(p => p.BasePrice)
                .Take(20)
                .ToArrayAsync();

            category.Products = products;
            return category;
        }

        public override async Task<Category[]> GetAllAsync ()
        {
            Category[] categories = await context.Categories
            .Include(c => c.SubCategories)
            .Include(c => c.ParentCategory)
            .ToArrayAsync();
            return categories;
        }
    }
}
