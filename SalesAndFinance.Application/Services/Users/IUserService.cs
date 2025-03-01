using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Users.Dto;

namespace SalesAndFinance.Application.Services.Users
{
    public interface IUserService
    {
        Task<ResponseResult<string>> SignUpAsync(UserRequestDto input);
    }
}
