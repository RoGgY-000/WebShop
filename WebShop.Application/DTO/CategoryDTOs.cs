using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateCategoryRequest (string Name, int? ParentCategoryId);
    public record CategoryResponse (int Id, string Name, int? ParentCategoryId);
}
