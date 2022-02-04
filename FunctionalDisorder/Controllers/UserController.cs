using FunctionalDisorder.Models.ActionDTOs;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto model)
        {
            var userDto = await _serviceManager.UserService.CreateAsync(model);
            return Ok(userDto.GuidId);
        }
    }
}
