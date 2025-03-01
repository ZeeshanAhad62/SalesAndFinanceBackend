
using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Auth.Dto;

namespace SalesAndFinance.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<ResponseResult<string>> LoginAsync(UserLoginRequestDto input);
    }
}
