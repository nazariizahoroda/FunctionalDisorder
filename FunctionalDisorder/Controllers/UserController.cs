using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Service_interfaces;
using System.Threading.Tasks;

namespace FunctionalDisorder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("getUser/{userId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "RegistredUser")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var userDto = await _serviceManager.UserService.GetUserByIdAsync(userId);
            return Ok(userDto);
        }
    }
}
