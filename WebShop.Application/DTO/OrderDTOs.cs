using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateOrderRequest (Guid UserId, int BranchId, int StatusId);
    public record OrderResponse (Guid Id, Guid UserId, int BranchId, int StatusId);
}
