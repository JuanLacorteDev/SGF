using Microsoft.EntityFrameworkCore;
using SGF.Data.Context;
using SGF.Domain.Entities;
using SGF.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGF.Data.Repository
{
    public class MesRepository : RepositoryBase<Mes>, IMesRepository
    {
        public MesRepository(SGFDbContext context) : base(context) { }

        public async Task<List<Mes>> ObterMesesApartir(Guid mesId, int numAno)
        {
            var mesInicio = await ObterMesesPorAno(numAno);
            var result = await DbSet.OrderBy(m => m.Identificador_Numerico).ToListAsync();
            return result.Skip(mesInicio.Find(m => m.Id == mesId).Identificador_Numerico - 1).ToList();
        }

        public async Task<List<Mes>> ObterMesesPorAno(int numAno)
        {
            return await DbSet.Where(m => m.Ano == numAno).ToListAsync();
        }
    }
}
