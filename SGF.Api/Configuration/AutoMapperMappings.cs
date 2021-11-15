using AutoMapper;
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
            CreateMap<DespesaVM, Despesa>()
                .ForMember(dest => dest.DespesaMeses,
                           opt => opt.MapFrom<DespesaMesesResolver>());

            CreateMap<Despesa, DespesaVM>();
            CreateMap<DespesaCategoriasMesesVM, Despesa>().ReverseMap();
            CreateMap<DespesaMesVM, DespesaMes>().ReverseMap();
            #endregion

            #region Mapper Categoria e VM's
            CreateMap<CategoriaVM, Categoria>().ReverseMap();
            CreateMap<CategoriaDespesasVM, Categoria>().ReverseMap();
            #endregion

            #region Mapper Remuneracao e VM's
            CreateMap<RemuneracaoVM, Remuneracao>()
                .ForMember(dest => dest.RemuneracaoMeses, 
                           opt => opt.MapFrom<RemuneracaoMesesResolver>());

            CreateMap<Remuneracao, RemuneracaoVM>();
            CreateMap<RemuneracaoMesVM, RemuneracaoMes>().ReverseMap();
            #endregion

            #region Mapper Mes e VM's
            CreateMap<MesVM, Mes>().ReverseMap();
            #endregion

        }
        #endregion

        #region metodos de auxilio para resolução de configuraçoes mais complexas do mapper 
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
                //em caso de remuneração mensal a criação da entidades relacionais é feita manualmente no service.
                if (!remuneracao.SalarioMensal)
                {
                    list.Add(new RemuneracaoMes
                    {
                        MesId = remuneracao.MesId,
                        RemuneracaoId = remuneracao.Id
                    });
                    return list;
                }
                return list;
            }
        }
        #endregion
    }
}
