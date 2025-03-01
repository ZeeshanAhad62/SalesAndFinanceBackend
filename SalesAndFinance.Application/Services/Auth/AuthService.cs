using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Auth.Dto;
using SalesAndFinance.Domain.Interfaces;

namespace SalesAndFinance.Application.Services.Auth
{
    internal class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ResponseResult<string>> LoginAsync(UserLoginRequestDto input)
        {
            ResponseResult<string> response = new();
            try
            {
                string email = input.Email;
                string password = input.Password;

                var request = await _authRepository.LoginAsync(email, password);

                response.Result = request;
                response.ResponseStatus = ResponseStatuses.Success;

            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.ResponseStatus = ResponseStatuses.InternalServerError ;
            }
            return response;
        }
    }
}
