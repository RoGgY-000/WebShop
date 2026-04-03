using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateCategoryRequest (string Name, Guid? ParentCategoryId) : IRequest;
    public record UpdateCategoryRequest (Guid Id, string Name, Guid? ParentCategoryId) : IRequest;
    public record CategoryResponse (Guid Id, string Name, Guid? ParentCategoryId, CategoryResponse[] SubCategories, Domain.Entities.Attribute[] Attributes, ProductResponse[] Products);
}
