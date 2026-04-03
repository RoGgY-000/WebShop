using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Domain.Entities;
using WebShop.Infrastructure;

namespace WebShop.WebApi.Controllers
{

    [ApiController]
    [Route("api/products/")]
    public class ProductsController 
        (ProductService productService,
        FileService fileService) 
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create (CreateProductRequest request)
        {
            ProductResponse result = await productService.CreateProductAsync(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get (Guid id)
        {
            ProductResponse result = await productService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update (UpdateProductRequest request)
        {
            ProductResponse result = await productService.Update(request);
            return Ok(result);
        }
    }
}
