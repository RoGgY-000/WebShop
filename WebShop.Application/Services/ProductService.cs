using Mapster;
using FluentValidation;
using FluentValidation.Results;
using WebShop.Application.Validators;
using WebShop.Application.DTO;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class ProductService
        (IRepository<Product, Guid> repository,
        IUnitOfWork unitOfWork,
        ProductValidator validator)
        : BaseService<Product, Guid, ProductResponse>
        (repository, unitOfWork)
    {
        public async Task<ProductResponse> CreateProductAsync (CreateProductRequest request)
        {
            Product product = request.Adapt<Product>();
            ValidationResult result = validator.Validate(product);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            repository.Add(product);
            await unitOfWork.SaveChangesAsync();
            return product.Adapt<ProductResponse>();
        }
    }
}
