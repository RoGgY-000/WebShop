using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Application.Common;

namespace WebShop.Application.DTO
{
    public record CreateRoleRequest (string Name) : IRequest;
    public record UpdateRoleRequest (Guid Id, string Name) : IRequest;
	public record RoleResponse (Guid Id, string Name);
}
