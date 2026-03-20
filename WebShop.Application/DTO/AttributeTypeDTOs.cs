using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateAttributeTypeRequest (string Name);
    public record AttributeTypeResponse (int Id, string Name);
}
