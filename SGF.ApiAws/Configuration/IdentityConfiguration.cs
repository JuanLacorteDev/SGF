using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGF.ApiAws.Data;


namespace SGF.ApiAws.Configuration
{
    public static class IdentityConfiguration
    {

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, 
                                                                       IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AspNetRolesUsers")));

            services.AddDefaultIdentity<IdentityUser>() //adicionando identidade padrão
                .AddRoles<IdentityRole>() //adicionando roles padrões
                .AddEntityFrameworkStores<ApplicationDbContext>() //indica que estou trabalhando com entityframework
                //.AddErrorDescriber<IdentityMensagensPortugues>() //adiciona a configuração de customização de mensagens para português
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
