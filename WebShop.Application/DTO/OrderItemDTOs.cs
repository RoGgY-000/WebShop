using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateOrderItemRequest (Guid OrderId, Guid ProductId, decimal Price, int Quantity);
    public record OrderItemResponse (Guid Id, Guid OrderId, Guid ProductId, decimal Price, int Quantity);
}
