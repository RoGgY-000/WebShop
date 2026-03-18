using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync (CancellationToken cancellationToken = default);
    }
}
