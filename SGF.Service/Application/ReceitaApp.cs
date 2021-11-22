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
    public class ReceitaApp : IReceitaApp
    {
        protected readonly IReceitaService _remuneracaoService;
        protected readonly IMapper _mapper;

        public ReceitaApp(IReceitaService remurenacaoService,
                              IMapper mapper)
        {
            _remuneracaoService = remurenacaoService;
            _mapper = mapper;
        }

        public async Task Adicionar(ReceitaVM remueracao)
        {
            await _remuneracaoService.Adicionar(_mapper.Map<Receita>(remueracao));
        }

        public async Task<List<ReceitaVM>> ObterReceitas()
        {
            throw new NotImplementedException();
        }

    }
}
