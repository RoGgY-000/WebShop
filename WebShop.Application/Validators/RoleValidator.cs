using FluentValidation;
using WebShop.Domain.Entities;

namespace WebShop.Application.Validators
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator ()
        {
            RuleFor(r => r.Name)
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("Имя роли не может быть пустым");
        }
    }
}
