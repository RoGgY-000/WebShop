using FluentValidation;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Http;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class ProductImageService
        (IRepository<ProductImage, Guid> repository,
        IUnitOfWork unitOfWork,
        ProductImageValidator validator,
        IFileService fileService)
        : BaseService<ProductImage, Guid, ProductImageResponse>
        (repository, unitOfWork)
    {
        public async Task<ProductImageResponse> CreateProductImageAsync (CreateProductImageRequest request, IFormFile file)
        {
            ProductImage productImage = request.Adapt<ProductImage>();
            ValidationResult result = validator.Validate(productImage);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            repository.Add(productImage);
            await fileService.SaveFileAsync(file, productImage);
            await unitOfWork.SaveChangesAsync();
            return productImage.Adapt<ProductImageResponse>();
        }
        public async Task<ProductImageResponse> GetProductImageAsync (GetProductImageRequest request)
        {
            ProductImage productImage = request.Adapt<ProductImage>();
            ValidationResult result = validator.Validate(productImage);
            return !result.IsValid 
                ? throw new ValidationException(result.Errors) 
                : productImage.Adapt<ProductImageResponse>();
        }
    }
}
