using FluentValidation;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
		public ProductValidator (ICatalogRepository repository)
		{
			RuleFor(c => c.Name)
				.NotNull()
				.NotEmpty()
				.WithMessage("Название не может быть пустым");

			RuleFor(c => c.CategoryId)
				.MustAsync(async (id, cancellation) =>
				{
					Category? category = await repository.GetCategoryAsync(id);
					return category != null && category.Id == id;
				})
				.WithMessage("Родительская категория не найдена");
			RuleFor(c => c.CategoryId)
				.MustAsync(async (id, cancellation) =>
				{
					Category? category = await repository.GetCategoryAsync(id);
					return category != null && category.SubCategories.Count == 0;
				})
				.WithMessage("Категория не может содержать товары и подкатегории одновременно");

			RuleFor(c => c.BasePrice)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Цена не может быть отрицательной");
		}
	}
}
