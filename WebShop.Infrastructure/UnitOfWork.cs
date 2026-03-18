using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Interfaces;

namespace WebShop.Infrastructure
{
    public class UnitOfWork (AppDbContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync (CancellationToken cancellationToken = default)
            => await context.SaveChangesAsync(cancellationToken);
    }
}
