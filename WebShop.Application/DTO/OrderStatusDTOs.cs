using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateOrderStatusRequest (string Name);
    public record OrderStatusResponse (Guid Id, string Name);
}
