using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Auth.Dto;
using SalesAndFinance.Domain.Interfaces;
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Application.Services.Auth
{
    internal class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ResponseResult<User>> LoginAsync(UserLoginRequestDto input)
        {
            ResponseResult<User> response = new();
            try
            {
                string email = input.Email;
                string password = input.Password;

                var request = await _authRepository.LoginAsync(email);
                if (request != null)
                {
                    bool checkPassword = BCrypt.Net.BCrypt.Verify(password, request.PasswordHash);
                    if (checkPassword == false)
                    {
                        response.Error = "Password is inCorrect";
                        response.ResponseStatus = ResponseStatuses.Unauthorized;

                        return response;
                    }
                }
                else
                {
                    response.Error = "emial is not valid";
                    response.ResponseStatus = ResponseStatuses.Unauthorized;

                    return response;
                }

                response.Result = request;
                response.ResponseStatus = ResponseStatuses.Success;

            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.ResponseStatus = ResponseStatuses.InternalServerError;
            }
            return response;
        }
    }
}
