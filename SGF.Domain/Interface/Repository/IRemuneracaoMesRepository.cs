using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Repository
{
    public interface IRemuneracaoMesRepository : IRepositoryBase<RemuneracaoMes>, IDisposable
    {
        Task<List<RemuneracaoMes>> ObterRemuneracaoMesSalarioMensal(int mesInicioNumero, int numAno);
        Task RemoverEntidades(List<RemuneracaoMes> remuneracoesMeses);
    }
}
