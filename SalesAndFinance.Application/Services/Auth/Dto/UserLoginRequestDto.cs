using System.ComponentModel.DataAnnotations;

namespace SalesAndFinance.Application.Services.Auth.Dto
{
    public class UserLoginRequestDto
    {
        [EmailAddress]
        public required string Email { get; set; }

        public required string Password { get; set; }

    }
}
