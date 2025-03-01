using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Users.Dto;
using SalesAndFinance.Domain;
using SalesAndFinance.Domain.Interfaces;


namespace SalesAndFinance.Application.Services.Users
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            
            _userRepository = userRepository;
        }

        public async Task<ResponseResult<string>> SignUpAsync(UserRequestDto input)
        {
            ResponseResult<string> response = new();
            try
            {
                var request = new User
                {
                    FirstName = input.firstName,
                    LastName = input.lastName,
                    Email = input.email,
                    PasswordHash = input.password,
                    ContactNumber = input.contactNumber,
                    CreatedBy = 0,
                };

                var result = await _userRepository.SignUpAsync(request);

                response.ResponseStatus = ResponseStatuses.Success;
                response.Result = result?.FirstName;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatuses.InternalServerError;
                response.Error = ex.Message;

            }
            return response;
        }
    }
}
