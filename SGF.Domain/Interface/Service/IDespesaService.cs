using SGF.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Service
{
    public interface IDespesaService : IDisposable
    {
        Task Adicionar(Despesa despesa);
        Task Atualizar(Despesa despesa);
        Task Remover(Guid id);
    }
}
