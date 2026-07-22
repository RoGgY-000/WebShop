using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using WebShop.Domain.Entities;

namespace WebShop.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.PasswordHash)
                .NotNull()
                .NotEmpty();

            RuleFor(u => u)
                .Must(
                u => !string.IsNullOrWhiteSpace(u.Email)
                || !string.IsNullOrWhiteSpace(u.PhoneNumber))
                .WithMessage("Необходимо указать либо электронную почту, либо номер телефона.");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Неверный формат электронной почты")
                .When(u => !string.IsNullOrWhiteSpace(u.Email));

            RuleFor(u => u.PhoneNumber)
                .Matches(@"^\d{10,12}$")
                .WithMessage("Неверный формат телефона")
                .When(u => !string.IsNullOrWhiteSpace(u.PhoneNumber));
        }
    }
}
