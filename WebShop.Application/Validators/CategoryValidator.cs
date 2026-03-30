using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator(IRepository<Category, Guid> repository)
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
                    Category? parent = await repository.GetByIdAsync(id.Value);
                    return parent != null;
                })
                .WithMessage("Родительская категория не найдена");
        }
    }
}
