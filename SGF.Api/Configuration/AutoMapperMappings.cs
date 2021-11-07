using AutoMapper;
using SGF.Application.ViewModels;
using SGF.Domain.Entities;

namespace SGF.Api.AutoMapperConfiguration
{
    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {
            CreateMap<DespesaVM, Despesa>().ReverseMap();
            CreateMap<CategoriaVM, Categoria>().ReverseMap();
            CreateMap<MesVM, Mes>().ReverseMap();
            CreateMap<DespesaMesVM, DespesaMes>().ReverseMap();
            CreateMap<RemuneracaoVM, Remuneracao>().ReverseMap();
            CreateMap<RemuneracaoMesVM, RemuneracaoMes>().ReverseMap();
        }
    }
}
