using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Domain.Entities;

namespace WebShop.WebApi.Controllers
{
	[ApiController]
	[Route("api/category")]
	public class CategoryController
		(BaseService<Category, CategoryResponse> service)
		: ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> CreateCategory (CreateCategoryRequest request)
		{
			CategoryResponse response =  await service.CreateAsync(request);
			return Created($"api/catalog/{response.Id}",response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory (UpdateCategoryRequest request)
		{
			CategoryResponse result = await service.UpdateAsync(request);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCategory (Guid id)
		{
			await service.RemoveById(id);
			return NoContent();
		}
	}
}
