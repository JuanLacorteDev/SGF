using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Repository
{
    public interface IMesRepository: IRepositoryBase<Mes>
    {
        Task<List<Mes>> ObterMesesPorAno(int numAno);
        Task<List<Mes>> ObterMesesApartir(Guid mesId, int numAno);
    }
}
