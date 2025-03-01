namespace SalesAndFinance.Application.Services.Users.Dto
{
    public class UserRequestDto
    {
        public string firstName { get; set; } = null!;

        public string? lastName { get; set; }

        public string email { get; set; } = null!;

        public string? contactNumber { get; set; }

        public string password { get; set; } = null!;

    }
}
