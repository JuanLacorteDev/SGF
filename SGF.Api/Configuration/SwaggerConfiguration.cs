using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SGF.Api.Configuration
{
    public static class SwaggerConfiguration
    {

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI();
            return app;
        }
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "V1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "ToDo API",
                        Description = "A simple example ASP.NET Core Web API",
                        Contact = new OpenApiContact
                        {
                            Name = "Juan Henrique",
                            Email = "criarEmailDeSuporteAplicacao@hotmail.com",
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT",
                        }
                    });
            });

            return services;
        }
    }
}
