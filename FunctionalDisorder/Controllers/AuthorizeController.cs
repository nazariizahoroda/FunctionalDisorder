using FunctionalDisorder.Models.ActionDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Service_interfaces;
using System.Threading.Tasks;

namespace FunctionalDisorder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IServiceManager _userManager;

        public AuthorizeController(IServiceManager serviceManager)
        {
            _userManager = serviceManager;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModelDto model)
        {
            var user = await _userManager.UserService.CreateUserAsync(model);

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInModelDto model)
        {
            var jwt = await _userManager.UserService.SignInUserAsync(model);

            return Ok(jwt);
        }
    }
}
