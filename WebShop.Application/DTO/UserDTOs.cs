using WebShop.Application.Common;

namespace WebShop.Application.DTO
{
    public record CreateUserRequest (string FirstName, string LastName, string Email, string PhoneNumber, string PasswordHash) : IRequest;
    public record UpdateUserRequest (Guid Id, string FirstName, string LastName, string Email, string PhoneNumber) : IRequest;
    public record UpdateUserPasswordRequest (Guid Id, string PasswordHash) : IRequest;
    public record UserResponse (Guid Id, string FirstName, string LastName, string Email, string PhoneNumber);
}
