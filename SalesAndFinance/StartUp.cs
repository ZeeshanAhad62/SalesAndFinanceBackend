using Microsoft.EntityFrameworkCore;
using SalesAndFinance.Infrastructure.Data;

namespace SalesAndFinance
{
    public class StartUp
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine(connectionString);

            builder.Services.AddDbContext<SalesAndFinanceDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add other services here, if needed
        }

    }
}
