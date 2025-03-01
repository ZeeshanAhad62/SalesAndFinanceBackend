
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

            // Add services to the container.
            builder.Services.AddDbContext<SalesAndFinanceDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
