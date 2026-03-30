using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;

namespace WebShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/categories/")]
    public class CategoriesController
        (CategoryService categoryService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create (CreateCategoryRequest request)
        {
            CategoryResponse result = await categoryService.CreateCategoryAsync(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get (Guid id)
        {
            CategoryResponse result = await categoryService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetRoot ()
        {
            CategoryResponse[] result = await categoryService.GetRootAsync();
            return Ok(result);
        }
    }
}
