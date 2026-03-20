using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class OrderService
        (IRepository<Order, Guid> repository,
        IUnitOfWork unitOfWork,
        OrderValidator validator)
        : BaseService<Order, Guid, OrderResponse>
        (repository, unitOfWork)
    {
    }
}
