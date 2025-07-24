using Microsoft.AspNetCore.Mvc;
using SalesAndFinance.Application.Services.Auth;
using SalesAndFinance.Application.Services.Auth.Dto;
using SalesAndFinance.Application.Common;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesAndFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private IConfiguration _config;
     
        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequestDto input)
        {
            var response = await _authService.LoginAsync(input);

            if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

            if (response.ResponseStatus == ResponseStatuses.Unauthorized)
                return StatusCode(StatusCodes.Status401Unauthorized, response.Result);

            string token = GenerateJwtToken(Convert.ToString(response.Result.Id));
            string uName = response.Result.FirstName + " " + response.Result.LastName;
            return Ok(new { token, uName });
        }

        private string GenerateJwtToken(string userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId)
                }),
                Expires = DateTime.Now.AddMinutes(30),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = creds
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
