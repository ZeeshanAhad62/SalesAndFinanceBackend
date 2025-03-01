using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAndFinance.Application.Services.Users;
using SalesAndFinance.Application.Services.Users.Dto;

namespace SalesAndFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(UserRequestDto input)
        {
            var result = await _userService.SignUpAsync(input);

            return Ok(result);
        }
    }
}
