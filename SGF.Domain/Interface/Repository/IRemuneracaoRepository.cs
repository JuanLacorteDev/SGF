using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Repository
{
    public interface IRemuneracaoRepository: IRepositoryBase<Remuneracao>, IDisposable
    {
        Task<List<Remuneracao>> ObterRemuneracaoPorMes(Guid MesId);
    }
}
