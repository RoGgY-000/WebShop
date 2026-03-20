using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Domain.Entities;
using WebShop.Infrastructure;

namespace WebShop.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
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
    }
}
