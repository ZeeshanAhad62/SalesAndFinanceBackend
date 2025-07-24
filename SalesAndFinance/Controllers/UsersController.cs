using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAndFinance.Application.Services.Users;
using SalesAndFinance.Application.Services.Users.Dto;
using SalesAndFinance.Application.Common;

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
        [Route("SignUp")]
        public async Task<IActionResult> SignUpAsync(UserRequestDto input)
        {
            var result = await _userService.SignUpAsync(input);

            if (result.ResponseStatus == ResponseStatuses.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, result.Error);

            return Ok(new { result });
        }
    }
}
