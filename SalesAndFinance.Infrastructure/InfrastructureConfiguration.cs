using Microsoft.Extensions.DependencyInjection;
using SalesAndFinance.Domain.Interfaces;
using SalesAndFinance.Infrastructure.Repositories;

namespace SalesAndFinance.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
