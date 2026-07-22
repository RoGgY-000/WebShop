using FluentValidation;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator(ICatalogRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Название не может быть пустым");

            RuleFor(c => c.ParentCategoryId)
                .MustAsync(async (id, cancellation) =>
                {
                    if ( id == null )
                    {
                        return true;
                    }
                    Category? parent = await repository.GetCategoryAsync(id.Value);
                    return parent != null;
                })
                .WithMessage("Родительская категория не найдена");

            RuleFor(c => c.ParentCategoryId)
                .MustAsync(async (id, cancellation) =>
                {
                    if ( id == null )
                    {
                        return true;
                    }
                    Category? parent = await repository.GetCategoryAsync(id.Value);
                    return parent != null && parent.Products.Count == 0;
                })
                .WithMessage("Категория не может содержать товары и подкатегории одновременно");
        }
    }
}
