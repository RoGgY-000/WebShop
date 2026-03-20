using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Infrastructure;

namespace WebShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController
        (ProductImageService productImageService,
        FileService fileService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get (CreateProductImageRequest request)
        {
            ProductImageResponse result = await productImageService.CreateProductImageAsync(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create (GetProductImageRequest request)
        {
            ProductImageResponse result = await productImageService.GetProductImageAsync(request);
            return Ok(result);
        }
    }
}
