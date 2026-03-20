using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateAttributeRequest (string Name, int TypeId);
    public record AttributeResponse (int Id, string Name, int TypeId);
}
