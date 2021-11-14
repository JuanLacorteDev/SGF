﻿using Microsoft.Extensions.DependencyInjection;
using SGF.Application.Application;
using SGF.Application.Interfaces.Application;
using SGF.Data.Context;
using SGF.Data.Repository;
using SGF.Domain.Interface.Repository;
using SGF.Domain.Interface.Service;
using SGF.Domain.Interfaces.Notification;
using SGF.Domain.Notifications;
using SGF.Domain.Services;

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
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IRemuneracaoRepository, RemuneracaoRepository>();
            services.AddScoped<IMesRepository, MesRepository>();
            services.AddScoped<IRemuneracaoMesRepository, RemuneracaoMesRepository>();
            #endregion

            #region Configuração de serviços
            services.AddScoped<IDespesaService, DespesaService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IRemuneracaoService, RemuneracaoService>();
            #endregion

            #region Configuração Application
            services.AddScoped<IDespesaApp, DespesaApp>();
            services.AddScoped<ICategoriaApp, CategoriaApp>();
            services.AddScoped<IRemuneracaoApp, RemuneracaoApp>();
            #endregion

            #region Configurações incomuns, configuraçoes unicas que não precisam de uma região dedicada
            services.AddScoped<INotificador, Notificador>();
            #endregion

            return services;
        }
    }
}
