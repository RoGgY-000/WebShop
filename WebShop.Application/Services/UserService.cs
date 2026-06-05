using Mapster;
using FluentValidation.Results;
using FluentValidation;
using WebShop.Application.DTO;
using WebShop.Domain.Interfaces;
using WebShop.Domain.Entities;
using WebShop.Application.Validators;

namespace WebShop.Application.Services
{
    public class UserService 
        (IRepository<User> repository,
        IValidator<User> validator)
        : BaseService<User, UserResponse>
        (repository, validator)
    {
        public async Task<UserResponse> CreateUserAsync (CreateUserRequest request)
        {
            User user = request.Adapt<User>();
            ValidationResult result = validator.Validate(user);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            repository.Add(user);
            await repository.SaveChangesAsync();
            return user.Adapt<UserResponse>();
        }
    }
}
