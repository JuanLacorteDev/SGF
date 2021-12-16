using AutoMapper;
using SGF.Application.ViewModels;
using SGF.Application.ViewModels.Entidades;
using SGF.Application.ViewModels.QueryEntidades;
using SGF.Domain.Entities;
using SGF.Domain.Entities.QueryEntidades;
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
            CreateMap<DespesaAdicionarVM, Despesa>().ReverseMap();
            CreateMap<DespesaListarVM, Despesa>().ReverseMap();

            CreateMap<FiltroDespesaVM, FiltroDespesa>().ReverseMap();
            #endregion

            #region Mapper Categoria e VM's
            CreateMap<CategoriaAdicionarVM, Categoria>().ReverseMap();
            CreateMap<CategoriaListarVM, Categoria>().ReverseMap();
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
