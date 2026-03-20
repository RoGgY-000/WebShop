using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class OrderStatusService
        (IRepository<OrderStatus, int> repository,
        IUnitOfWork unitOfWork,
        OrderStatusValidator validator)
        : BaseService<OrderStatus, int, OrderStatusResponse>
        (repository, unitOfWork)
    {
    }
}
