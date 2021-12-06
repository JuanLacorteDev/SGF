using AutoMapper;
using SGF.Application.ViewModels;
using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGF.ApiAws.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        #region configs centrais
        public AutoMapperConfiguration()
        {
            #region Mapper Despesa e VM's
            CreateMap<DespesaVM, Despesa>().ReverseMap();
            #endregion

            #region Mapper Categoria e VM's
            CreateMap<CategoriaVM, Categoria>().ReverseMap();
            CreateMap<CategoriaDespesasVM, Categoria>().ReverseMap();
            #endregion

            #region Mapper Remuneracao e VM's
            CreateMap<ReceitaVM, Receita>().ReverseMap();
            #endregion
        }
        #endregion

        #region metodos de auxilio para resolução de configuraçoes mais complexas do mapper 
        
        #endregion
    }
}
