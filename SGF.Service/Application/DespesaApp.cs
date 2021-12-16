using AutoMapper;
using SGF.Application.Interfaces.Application;
using SGF.Application.ViewModels.Entidades;
using SGF.Application.ViewModels.QueryEntidades;
using SGF.Domain.Entities;
using SGF.Domain.Entities.QueryEntidades;
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

        public async Task Adicionar(DespesaAdicionarVM despesa)
        {
            await _despesaService.Adicionar(_mapper.Map<DespesaAdicionarVM, Despesa>(despesa));
        }

        public async Task<List<DespesaListarVM>> ObterDespesas(FiltroDespesaVM filtro)
        {
            var retorno = await _despesaService.ObterDespesas(_mapper.Map<FiltroDespesa>(filtro));
            return _mapper.Map<List<DespesaListarVM>>(retorno);
        }
    }
}
