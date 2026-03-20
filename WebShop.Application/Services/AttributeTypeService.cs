using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class AttributeTypeService 
        (IRepository<AttributeType, int> repository,
        IUnitOfWork unitOfWork,
        AttributeTypeValidator validator)
        : BaseService<AttributeType, int, AttributeTypeResponse>
        (repository, unitOfWork)
    { 
    }
}
