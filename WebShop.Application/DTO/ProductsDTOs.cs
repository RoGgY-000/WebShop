using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.Common;

namespace WebShop.Application.DTO
{
    public record CreateProductRequest (string Name, Guid CategoryId, decimal BasePrice) : IRequest;
    public record UpdateProductRequest (Guid Id, string Name, Guid CategoryId, decimal BasePrice) : IRequest;
	public record ProductResponse (Guid Id, string Name, Guid CategoryId, decimal BasePrice);
}
