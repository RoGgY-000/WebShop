using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateRoleRequest (string Name);
    public record RoleResponse (int Id, string Name);
}
