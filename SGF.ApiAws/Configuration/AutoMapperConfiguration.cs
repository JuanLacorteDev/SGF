using AutoMapper;
using SGF.Application.ViewModels.Entidades;
using SGF.Domain.Entities;

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
            CreateMap<CategoriaListarVM, Categoria>().ReverseMap();
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
