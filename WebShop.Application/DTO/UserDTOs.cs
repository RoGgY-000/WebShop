using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateUserRequest (string FirstName, string LastName,string Email,string PhoneNumber,string PasswordHash);
    public record UpdateUserNameRequest (string Email, string PasswordHash);
    public record UpdateUserPasswordRequest (string Email, string PasswordHash);
    public record UserResponse (Guid Id, string FirstName, string LastName, string Email, string PhoneNumber);
}
