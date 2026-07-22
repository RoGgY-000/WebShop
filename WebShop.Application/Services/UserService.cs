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
        IRepository<Role> roleRepository,
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

		public override async Task<UserResponse> UpdateAsync (Guid id, IRequest request)
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

        public async Task<UserResponse> AddRoleAsync (Guid userId, AddRoleToUserRequest request)
        {
			User user = await repository.GetByIdForUpdateAsync(userId) 
                ?? throw new NotFoundException("Пользователь не найден");
            Role role = await roleRepository.GetByIdForReadAsync(request.RoleId)
                ?? throw new NotFoundException("Роль не найдена");
            if ( user.Roles.Contains(role) )
            {
                throw new InvalidOperationException("Пользователь уже имеет эту роль");
            }
            user.Roles.Add(role);
            await repository.SaveChangesAsync();
            return user.Adapt<UserResponse>();
		}
    }
}
