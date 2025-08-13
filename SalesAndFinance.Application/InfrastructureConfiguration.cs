using Microsoft.Extensions.DependencyInjection;
using SalesAndFinance.Application.Services.Auth;
using SalesAndFinance.Application.Services.Category;
using SalesAndFinance.Application.Services.Units;
using SalesAndFinance.Application.Services.Users;
using SalesAndFinance.Domain.Common;

namespace SalesAndFinance.Infrastructure
{
    public static class ApplicationConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<CommonFunctions>();
            services.AddHttpContextAccessor();
        }
    }
}
