using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Domain.Entities;
using WebShop.Infrastructure;

namespace WebShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController 
        (BaseService<Product, ProductResponse> productService) 
        : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> Create (CreateProductRequest request)
        //{
        //    await productService.CreateAsync(request);
        //    return Created();
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get (Guid id)
        //{
        //    ProductResponse result = await productService.GetByIdAsync(id);
        //    return Ok(result);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update (UpdateProductRequest request)
        //{
        //    ProductResponse result = await productService.UpdateAsync(request);
        //    return Ok(result);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove (Guid id)
        //{
        //    await productService.RemoveById(id);
        //    return NoContent();
        //}
    }
}
