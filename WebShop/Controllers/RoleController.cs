using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Domain.Entities;

namespace WebShop.WebApi.Controllers
{
	[Route("api/role")]
	[ApiController]
	public class RoleController
		(BaseService<Role, RoleResponse> service)
		: ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Create (CreateRoleRequest request)
		{
			RoleResponse result = await service.CreateAsync(request);
			return Created($"api/roles/{result.Id}",result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get (Guid id)
		{
			RoleResponse result = await service.GetByIdAsync(id);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update (UpdateRoleRequest request)
		{
			RoleResponse result = await service.UpdateAsync(request);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove (Guid id)
		{
			await service.RemoveByIdAsync(id);
			return NoContent();
		}
	}
}
