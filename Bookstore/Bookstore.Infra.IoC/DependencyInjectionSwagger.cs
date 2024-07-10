using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Bookstore.Infra.IoC;

public static class DependencyInjectionSwagger
{

    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bookstore.API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                //definir configuraçoes
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the bearer scheme. \r\n\r\n Enter 'Bearer' [space]" +
                "and then your token in th text input below. \r\n\r\nExample: \"Bearer 1234abcdef\"",
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                //definir configuraçoes
                {
                      new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                }
            });
        });
        return services;
    }
}
