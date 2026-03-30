using System;
using System.Collections.Generic;
using System.Text;
using Mapster;
using FluentValidation;
using FluentValidation.Results;
using WebShop.Application.Validators;
using WebShop.Application.DTO;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class StockService
         (IRepository<Stock, Guid> repository,
        IUnitOfWork unitOfWork,
        StockValidator validator)
        : BaseService<Stock, Guid, StockResponse>
        (repository, unitOfWork)
    {
        public async Task<StockResponse> CreateStockAsync (CreateStockRequest request)
        {
            Stock stock = request.Adapt<Stock>();
            ValidationResult result = validator.Validate(stock);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            repository.Add(stock);
            await unitOfWork.SaveChangesAsync();
            return stock.Adapt<StockResponse>();
        }
    }
}
