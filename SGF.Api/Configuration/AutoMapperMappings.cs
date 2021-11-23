﻿using AutoMapper;
using SGF.Application.ViewModels;
using SGF.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SGF.Api.AutoMapperConfiguration
{
    public class AutoMapperMappings : Profile
    {
        #region configs centrais
        public AutoMapperMappings()
        {
            #region Mapper Despesa e VM's
            CreateMap<DespesaVM, Despesa>().ReverseMap();

            CreateMap<Despesa, DespesaVM>();
            #endregion

            #region Mapper Categoria e VM's
            CreateMap<CategoriaVM, Categoria>().ReverseMap();
            CreateMap<CategoriaDespesasVM, Categoria>().ReverseMap();
            #endregion

            #region Mapper Remuneracao e VM's
            CreateMap<ReceitaVM, Receita>().ReverseMap();

            CreateMap<Receita, ReceitaVM>().ReverseMap();
            #endregion
        }
        #endregion

        #region metodos de auxilio para resolução de configuraçoes mais complexas do mapper 

        #endregion
    }
}
