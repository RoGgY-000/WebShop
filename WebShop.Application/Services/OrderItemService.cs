using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class OrderItemService
        (IRepository<OrderItem, Guid> repository,
        IUnitOfWork unitOfWork,
        OrderItemValidator validator)
        : BaseService<OrderItem, Guid, OrderItemResponse>
        (repository, unitOfWork)
    {
    }
}
