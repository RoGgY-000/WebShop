using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateProductRequest (string Name, int CategoryId, decimal BasePrice);
    public record ProductResponse (Guid Id, string Name, int CategoryId, decimal BasePrice);
}
