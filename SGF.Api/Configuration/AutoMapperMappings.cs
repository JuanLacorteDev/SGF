using AutoMapper;
using SGF.Application.ViewModels.Entidades;
using SGF.Domain.Entities;

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
            #endregion

            #region Mapper Categoria e VM's
            CreateMap<CategoriaListarVM, Categoria>().ReverseMap();
            CreateMap<CategoriaAdicionarVM, Categoria>().ReverseMap();
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
