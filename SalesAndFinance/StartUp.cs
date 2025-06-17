using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SalesAndFinance.Infrastructure.Data;
using Microsoft.OpenApi.Models;

namespace SalesAndFinance
{
    public static class StartUp
    {
     
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine(connectionString);

            builder.Services.AddDbContext<SalesAndFinanceDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add other services here, if needed
        }

        public static void AddAuthentication(WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                };
            });

            builder.Services.AddAuthorization();
        }

        public static void SwaggerGen(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                // JWT Authentication setup for Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\n\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6...\""
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {   
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

    }
}
