using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;
using WebShop.Application.DTO;
using Mapster;

namespace WebShop.Application.Services
{
    public class BranchService 
        (IRepository<Branch, Guid> repository,
        IUnitOfWork unitOfWork)
        : BaseService<Branch, Guid, BranchResponse>
        (repository, unitOfWork)
    {
        public async Task<BranchResponse> CreateBranchAsync (CreateBranchRequest request)
        {
            Branch branch = new() { Name=request.Name, Address=request.Address };
            repository.Add(branch);
            await unitOfWork.SaveChangesAsync();
            return branch.Adapt<BranchResponse>();
        }
    }
}
