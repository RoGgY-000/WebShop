using Microsoft.AspNetCore.Mvc;
using WebShop.Application.Services;
using WebShop.Application.DTO;
namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController 
        (UserService userService) 
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create (CreateUserRequest request)
        {
            UserResponse result = await userService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update (UpdateUserRequest request)
        {
            UserResponse result = await userService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePassword (UpdateUserPasswordRequest request)
        {
            await userService.UpdateUserPasswordAsync(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove (Guid id)
        {
            await userService.RemoveByIdAsync(id);
            return NoContent();
        }
    }
}
