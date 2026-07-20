using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Application.Services;
using WebShop.Application.DTO;
namespace WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController (UserService userService) : ControllerBase
    {
        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> Create (CreateUserRequest request)
        //{
        //    UserResponse result = await userService.CreateUserAsync(request);
        //    return Ok(result);
        //}
    }
}
