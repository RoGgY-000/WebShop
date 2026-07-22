using WebShop.Application.Common;

namespace WebShop.Application.DTO
{
    public record CreateCategoryRequest (string Name, Guid? ParentCategoryId) : IRequest;
    public record UpdateCategoryRequest (Guid Id, string Name, Guid? ParentCategoryId) : IRequest;
    public record CategoryResponse (Guid Id, string Name, Guid? ParentCategoryId, CategoryResponse[] SubCategories, ProductResponse[] Products);
}
