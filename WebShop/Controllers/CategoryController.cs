using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Domain.Entities;

namespace WebShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/categories/")]
    public class CategoriesController
        (BaseService<Category,Guid,CategoryResponse> categoryService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            CategoryResponse[] result = await categoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get (Guid id)
        {
            CategoryResponse result = await categoryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create (CreateCategoryRequest request)
        {
            CategoryResponse result = await categoryService.Create(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update (UpdateCategoryRequest request)
        {
            CategoryResponse result = await categoryService.Update(request);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remove (Guid id)
        {
            CategoryResponse result = await categoryService.RemoveById(id);
            return Ok(result);
        }
    }
}
