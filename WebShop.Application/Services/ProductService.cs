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
        (IRepository<Product> repository,
        ProductValidator validator)
        : BaseService<Product, ProductResponse>
        (repository, validator)
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
            await repository.SaveChangesAsync();
            return product.Adapt<ProductResponse>();
        }

        public async Task<ProductResponse> Update (UpdateProductRequest request)
        {
            Product product = request.Adapt<Product>();
            ValidationResult result = validator.Validate(product);
            if ( !result.IsValid )
            {
                throw new ValidationException(result.Errors);
            }
            repository.Update(product);
            await repository.SaveChangesAsync();
            return product.Adapt<ProductResponse>();
        }
    }
}
