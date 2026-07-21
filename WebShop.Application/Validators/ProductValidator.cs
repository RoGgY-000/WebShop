using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
		public ProductValidator (IRepository<Product> repository, IRepository<Category> categoryRepo)
		{
			RuleFor(c => c.Name)
				.NotNull()
				.NotEmpty()
				.WithMessage("Название не может быть пустым");
			RuleFor(c => c.CategoryId)
				.MustAsync(async (id, cancellation) =>
				{
					Category? category = await categoryRepo.GetByIdForReadAsync(id);
					return category != null && category.Id == id;
				})
				.WithMessage("Родительская категория не найдена");
			RuleFor(c => c.BasePrice)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Цена не может быть отрицательной");
		}
	}
}
