using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class AttributeService (IRepository<Domain.Entities.Attribute, int> repository,
        IUnitOfWork unitOfWork,
        AttributeValidator validator)
        : BaseService<Domain.Entities.Attribute, int, AttributeResponse>
        (repository, unitOfWork)
    {
    }
}
