
using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Auth.Dto;
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<ResponseResult<User>> LoginAsync(UserLoginRequestDto input);
    }
}
