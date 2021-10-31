using SGF.Domain.Entities;
using SGF.Domain.Entities.Validations;
using SGF.Domain.Interface.Repository;
using SGF.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Services
{
    public class DespesaService : ServiceBase, IDespesaService
    {
        protected readonly IDespesaRepository _despesaRepository;
        public DespesaService(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public async Task Adicionar(Despesa despesa)
        {
            if (ExecutarValidacao(new DespesaValidator(), despesa)) return;

            await _despesaRepository.Adicionar(despesa);
        }

        public async Task Atualizar(Despesa despesa)
        {
            if (ExecutarValidacao(new DespesaValidator(), despesa)) return;

            await _despesaRepository.Atualizar(despesa);
        }

        public async Task Remover(Guid id)
        {
            await _despesaRepository.Remover(id);
        }

        public void Dispose()
        {
            _despesaRepository?.Dispose();
        }
    }
}
