using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateUserRequest (string Email,string PasswordHash);
    public record UserResponse (Guid Id, string Email);
}
