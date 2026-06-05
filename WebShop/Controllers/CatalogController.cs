using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Domain.Entities;

namespace WebShop.WebApi.Controllers
{
	[ApiController]
	[Route("api/catalog")]
	public class CatalogController
		(CatalogService service)
		: ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetCatalog ()
		{
			CategoryResponse[] result = await service.GetCatalogAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategory (Guid id)
		{
			CategoryResponse result = await service.GetCategoryAsync(id);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory (CreateCategoryRequest request)
		{
			await service.CreateCategoryAsync(request);
			return Created();
		}

		//[HttpPut]
		//public async Task<IActionResult> UpdateCategory (UpdateCategoryRequest request)
		//{
		//	CategoryResponse result = await service.UpdateAsync(request);
		//	return Ok(result);
		//}

		//[HttpDelete("{id}")]
		//public async Task<IActionResult> RemoveCategory (Guid id)
		//{
		//	await service.RemoveById(id);
		//	return NoContent();
		//}
	}
}
