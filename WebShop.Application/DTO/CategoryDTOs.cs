using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateCategoryRequest (string Name, Guid? ParentCategoryId);
    public record CategoryResponse (Guid Id, string Name, Guid? ParentCategoryId);
}
