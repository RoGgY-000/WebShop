using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;

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
	}
}
