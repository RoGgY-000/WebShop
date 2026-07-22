using WebShop.Domain.Common;

namespace WebShop.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string? Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; } = [];
        public ICollection<Category> SubCategories { get; set; } = [];
    }
}
