using FluentValidation;
using Mapster;
using WebShop.Application.Common;
using WebShop.Application.DTO;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Services
{
    public class UserService 
        (IRepository<User> repository,
        IValidator<User> validator)
        : BaseService<User, UserResponse>
        (repository, validator)
    {
        public async Task<UserResponse> UpdateUserPasswordAsync (UpdateUserPasswordRequest request)
        {
            if ( request.Id == Guid.Empty )
            {
                throw new ArgumentException("Неверный Id пользователя");
            }
			User user = await repository.GetByIdForUpdateAsync(request.Id) ?? throw new NotFoundException("Пользователь не найден");
            user.PasswordHash = request.PasswordHash;
			await validator.ValidateAndThrowAsync(user);
            repository.Update(user);
            await repository.SaveChangesAsync();
            return user.Adapt<UserResponse>();
        }

		public override async Task<UserResponse> UpdateAsync (IRequest request)
        {
            UpdateUserRequest? userRequest = request as UpdateUserRequest;
			if ( userRequest == null
                || userRequest.Id == Guid.Empty )
			{
				throw new ArgumentException("Неверный Id пользователя");
			}
			User user = await repository.GetByIdForReadAsync(userRequest.Id) ?? throw new NotFoundException("Пользователь не найден");
            User newUser = userRequest.Adapt<User>();
            newUser.PasswordHash = user.PasswordHash;
			await validator.ValidateAndThrowAsync(newUser);
			repository.Update(newUser);
			await repository.SaveChangesAsync();
			return newUser.Adapt<UserResponse>();
		}
    }
}
