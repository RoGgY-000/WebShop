using Microsoft.AspNetCore.Mvc;
using WebShop.Application.DTO;
using WebShop.Application.Services;
using WebShop.Domain.Entities;
using WebShop.Infrastructure;

namespace WebShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/products/{productId:guid}/images")]
    public class ProductImagesController
        (BaseService<ProductImage,Guid,ProductImageResponse>  productImageService,
        IFileService fileService)
        : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get (Guid id)
        {
            ProductImageResponse result = await productImageService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            ProductImageResponse[] result = await productImageService.GetAllAsync();
            return Ok(result);
        }

        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task<IActionResult> Create (Guid productId, CreateProductImageRequest request, [FromForm] IFormFile file)
        {
            ProductImageResponse result = await productImageService.Create(request);
            return Ok("https://localhost:5083/"+result);
        }
    }
}
