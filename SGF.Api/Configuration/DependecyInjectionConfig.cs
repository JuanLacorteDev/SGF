using Microsoft.Extensions.DependencyInjection;
using SGF.Data.Context;
using SGF.Data.Repository;
using SGF.Domain.Interface.Repository;
using SGF.Domain.Interfaces.Notification;
using SGF.Domain.Notifications;
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

            #region Configuração de repositórios
            services.AddScoped<IDespesaRepository, DespesaRepository>();
            #endregion

            #region Configuração de serviços

            #endregion

            #region Configurações incomuns, configuraçoes unicas que não precisam de uma região dedicada
            services.AddScoped<INotificador, Notificador>();
            #endregion

            return services;
        }
    }
}
