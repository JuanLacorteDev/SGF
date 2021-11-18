using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Service
{
    public interface IRemuneracaoService : IDisposable
    {
        Task Adicionar(Remuneracao remuneracao);
        Task<List<Remuneracao>> ObterRemuneracaoPorMes(Guid _mesId);
    }
}
