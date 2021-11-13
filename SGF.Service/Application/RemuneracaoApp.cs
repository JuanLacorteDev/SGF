using AutoMapper;
using SGF.Application.Interfaces.Application;
using SGF.Application.ViewModels;
using SGF.Domain.Entities;
using SGF.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Application.Application
{
    public class RemuneracaoApp : IRemuneracaoApp
    {
        protected readonly IRemuneracaoService _remuneracaoService;
        protected readonly IMapper _mapper;

        public RemuneracaoApp(IRemuneracaoService remurenacaoService,
                              IMapper mapper)
        {
            _remuneracaoService = remurenacaoService;
            _mapper = mapper;
        }

        public async Task Adicionar(RemuneracaoVM remueracao)
        {
            await _remuneracaoService.Adicionar(_mapper.Map<Remuneracao>(remueracao));
        }

        public async Task<RemuneracaoVM> ObterRemueracao(Guid MesId)
        {
            var result = await _remuneracaoService.ObterRemuneracaoPorMes(MesId);
            return _mapper.Map<RemuneracaoVM>(result);
        }
    }
}
