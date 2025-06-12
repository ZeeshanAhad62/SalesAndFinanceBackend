using Microsoft.AspNetCore.Mvc;
using SalesAndFinance.Application.Services.Auth;
using SalesAndFinance.Application.Services.Auth.Dto;
using SalesAndFinance.Application.Common;

namespace SalesAndFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginRequestDto input)
        {
            var response = await _authService.LoginAsync(input);

            if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

            return Ok(response);
        }
    }
}
