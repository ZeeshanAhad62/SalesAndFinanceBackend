
using Microsoft.EntityFrameworkCore;
using SalesAndFinance.Application;
using SalesAndFinance.Infrastructure;
using SalesAndFinance.Infrastructure.Data;

namespace SalesAndFinance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Enable logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            var sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Connection String: {sqlConnection}");

            builder.Services.AddDbContext<SalesAndFinanceDbContext>(options =>
                options.UseSqlServer(sqlConnection, sqlOptions =>
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    )
                )
            );
            //builder.Services.AddDbContext<SalesAndFinanceDbContext>(sqlConnection , options => options.UseSqlConnection(sqlConnection));
            // Add services to the container.

            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAllOrigins",
                                  policy =>
                                  {
                                      policy
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowAnyOrigin();
                                  });
            });

            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenAnyIP(8080);
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
