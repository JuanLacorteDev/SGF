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
    public class RemuneracaoMesRepository : RepositoryBase<RemuneracaoMes>, IRemuneracaoMesRepository
    {
        public RemuneracaoMesRepository(SGFDbContext context) : base(context) { }

        public async Task<List<RemuneracaoMes>> ObterRemuneracaoMesSalarioMensal(int mesInicioNumero, int numAno)
        {
            var result = await DbSet.Where(rm => rm.Remuneracao.SalarioMensal == true).OrderBy(rm => rm.Mes.Identificador_Numerico).ToListAsync();
            var skipPoint = result.IndexOf(result.Find(x => x.Mes.Identificador_Numerico == mesInicioNumero));
            var t = result.Skip(skipPoint).ToList();
            return t;
        }

        public async Task RemoverEntidades(List<RemuneracaoMes> remuneracoesMeses)
        {
            DbSet.RemoveRange(remuneracoesMeses);
            await SaveChanges();
        }
    }   
}
