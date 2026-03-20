using System;
using System.Collections.Generic;
using System.Text;
using Mapster;
using WebShop.Application.DTO;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class CategoryService
        (IRepository<Category, int> repository,
        IUnitOfWork unitOfWork)
        : BaseService<Category, int, CategoryResponse>
        (repository, unitOfWork)
    {
        public async Task<CategoryResponse> CreateCategoryAsync (CreateCategoryRequest request)
        {

            Category category = request.Adapt<Category>();
            repository.Add(category);
            await unitOfWork.SaveChangesAsync();
            return category.Adapt<CategoryResponse>();
        }
    }
}
