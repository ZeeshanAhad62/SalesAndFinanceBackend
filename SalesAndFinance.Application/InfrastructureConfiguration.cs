using Microsoft.Extensions.DependencyInjection;
using SalesAndFinance.Application.Services.Auth;
using SalesAndFinance.Application.Services.Users;

namespace SalesAndFinance.Infrastructure
{
    public static class ApplicationConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
