using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateStockRequest (Guid ProductId, int BranchId, decimal Price, int Quantity);
    public record StockResponse (Guid Id, Guid ProductId, int BranchId, decimal Price, int Quantity);
}
