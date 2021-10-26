using Microsoft.Extensions.DependencyInjection;
using SGF.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGF.Api.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDepedencies(this IServiceCollection services)
        {
            //configuração de context
            services.AddScoped<SGFDbContext>();

            #region Configuração de repositorios
            #endregion

            #region Configuração de serviços
            #endregion

            #region Configurações incomuns, configuraçoes unicas que nao precisam de uma região dedicada
            #endregion
            return services;
        }
    }
}
