using AutoMapper;
using SGF.Application.Interfaces.Application;
using SGF.Application.ViewModels;
using SGF.Domain.Entities;
using SGF.Domain.Interface.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGF.Application.Application
{
    public class DespesaApp : IDespesaApp
    {
        protected readonly IDespesaService _despesaService;
        protected readonly IMapper _mapper;
        public DespesaApp(IDespesaService despesaService,
                          IMapper mapper)
        {
            _despesaService = despesaService;
            _mapper = mapper;
        }

        public async Task Adicionar(DespesaVM despesa)
        {
            await _despesaService.Adicionar(_mapper.Map<DespesaVM, Despesa>(despesa));
        }

        public async Task<List<DespesaVM>> ObterDespesas()
        {
            var retorno = await _despesaService.ObterDespesas();
            return _mapper.Map<List<DespesaVM>>(retorno);
        }
    }
}
