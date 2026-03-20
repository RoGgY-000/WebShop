using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using Mapster;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class ProductImageService
        (IRepository<ProductImage, int> repository,
        IUnitOfWork unitOfWork,
        ProductImageValidator validator,
        IFileService fileService)
        : BaseService<ProductImage, int, ProductImageResponse>
        (repository, unitOfWork)
    {
        public async Task<ProductImageResponse> CreateProductImageAsync (CreateProductImageRequest request)
        {
            ProductImage productImage = request.Adapt<ProductImage>();
            ValidationResult result = validator.Validate(productImage);
            if (result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            repository.Add(productImage);
            await unitOfWork.SaveChangesAsync();
            return productImage.Adapt<ProductImageResponse>();
        }
        public async Task<ProductImageResponse> GetProductImageAsync (GetProductImageRequest request)
        {
            ProductImage productImage = request.Adapt<ProductImage>();
            ValidationResult result = validator.Validate(productImage);
            if (result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            return productImage.Adapt<ProductImageResponse>();
        }
    }
}
