using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Application.Validators;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class RoleService
        (IRepository<Role, int> repository,
        IUnitOfWork unitOfWork,
        RoleValidator validator)
        : BaseService<Role, int, RoleResponse>
        (repository, unitOfWork)
    {
    }
}
