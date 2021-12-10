using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Service
{
    public interface IDespesaService : IDisposable
    {
        Task<List<Despesa>> ObterDespesas(Guid userId);
        Task Adicionar(Despesa despesa);
        Task Atualizar(Despesa despesa);
        Task Remover(Guid id);
    }
}
