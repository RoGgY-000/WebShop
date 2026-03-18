using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.DTO;
using WebShop.Domain.Interfaces;
using WebShop.Domain.Entities;

namespace WebShop.Application.Services
{
    public class UserService 
        (IRepository<User, Guid> repository,
        IUnitOfWork unitOfWork)
    {
        public async Task<UserResponse> CreateUserAsync (CreateUserRequest request)
        {
            User user = new() { Email = request.Email, Passwordhash = request.PasswordHash };
            repository.Add(user);
            await unitOfWork.SaveChangesAsync();
            return new UserResponse(user.Id,user.Email);
        }
    }
}
