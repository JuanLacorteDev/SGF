using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SGF.ApiAws.Data;
using SGF.ApiAws.Extensions;
using System.Text;

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
                .AddEntityFrameworkStores<ApplicationDbContext>() //indica que estou trabalhando com entityframework pois o ApplicationDb herda de IdentityDbContext do EF core
                //.AddErrorDescriber<IdentityMensagensPortugues>() //adiciona a configuração de customização de mensagens para português
                .AddDefaultTokenProviders();


            //JWT 

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false; //obrigando a requisão vir de um httpS
                x.SaveToken = true;            //guarda o token no httpAuthenticationProperties
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    //validar o emissor e em seguida qual emissor é valido.
                    ValidateIssuer =  true,
                    ValidIssuer = appSettings.Emissor,

                    //validar audiencia e em seguida qual audiencia é valida.
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    
                };
                 
            });



            return services;
        }
    }
}
