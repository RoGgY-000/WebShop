using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Application.Services;
using WebShop.Application.DTO;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController (UserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create (CreateUserRequest request)
        {
            UserResponse result = await userService.CreateUserAsync(request);
            return Ok(result);
        }
    }
}
