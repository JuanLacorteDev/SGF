using AutoMapper;
using SGF.Application.ViewModels;
using SGF.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SGF.Api.AutoMapperConfiguration
{
    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {
            #region Mapper DespesaVM
            CreateMap<DespesaVM, Despesa>()
                .ForMember(dest => dest.DespesaMeses,
                           opt => opt.MapFrom<DespesaMesesResolver>());

            CreateMap<Despesa, DespesaVM>();
            CreateMap<DespesaCategoriasMesesVM, Despesa>().ReverseMap();
            CreateMap<DespesaMesVM, DespesaMes>().ReverseMap();
            #endregion

            #region Mapper CategoriasVM
            CreateMap<CategoriaVM, Categoria>().ReverseMap();
            CreateMap<CategoriaDespesasVM, Categoria>().ReverseMap();
            #endregion

            #region Mapper RemuneracaoVM
            CreateMap<RemuneracaoVM, Remuneracao>()
                .ForMember(dest => dest.RemuneracaoMeses, 
                           opt => opt.MapFrom<RemuneracaoMesesResolver>());

            CreateMap<Remuneracao, RemuneracaoVM>();
            CreateMap<RemuneracaoMesVM, RemuneracaoMes>().ReverseMap();
            #endregion

            #region Mapper MesVM
            CreateMap<MesVM, Mes>().ReverseMap();
            #endregion

        }



        private class DespesaMesesResolver : IValueResolver<DespesaVM, Despesa, List<DespesaMes>>
        {
            public List<DespesaMes> Resolve(DespesaVM despesaVm, Despesa despesa, List<DespesaMes> destMember, ResolutionContext context)
            {
                var list = new List<DespesaMes>();
                list.Add(new DespesaMes
                {
                    MesId = despesaVm.MesId,
                    DespesaId = despesa.Id
                });
                return list;
            }

        }

        private class RemuneracaoMesesResolver : IValueResolver<RemuneracaoVM, Remuneracao, List<RemuneracaoMes>>
        {
            public List<RemuneracaoMes> Resolve(RemuneracaoVM remuneracaoVM, Remuneracao remuneracao, List<RemuneracaoMes> destMember, ResolutionContext context)
            {
                var list = new List<RemuneracaoMes>();
                list.Add(new RemuneracaoMes
                {
                    MesId = remuneracao.MesId,
                    RemuneracaoId = remuneracao.Id
                });

                return list;
            }

        }
    }
}
