using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Infrastructure;

namespace WebShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/products/{productId:guid}/images")]
    public class ProductImagesController
        (ProductImageService productImageService,
        IFileService fileService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get (GetProductImageRequest request)
        {
            ProductImageResponse result = await productImageService.GetProductImageAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll (GetProductImageRequest request)
        {
            ProductImageResponse result = await productImageService.GetProductImageAsync(request);
            return Ok(result);
        }

        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task<IActionResult> Create (Guid productId, CreateProductImageRequest request, [FromForm] IFormFile file)
        {
            ProductImageResponse result = await productImageService.CreateProductImageAsync(request, file);
            return Ok("https://localhost:5083/"+result);
        }
    }
}
