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
        }
    }
}
