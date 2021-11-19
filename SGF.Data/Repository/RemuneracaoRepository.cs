using Microsoft.EntityFrameworkCore;
using SGF.Data.Context;
using SGF.Domain.Entities;
using SGF.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Data.Repository
{
    public class RemuneracaoRepository : RepositoryBase<Remuneracao>, IRemuneracaoRepository
    {
        public RemuneracaoRepository(SGFDbContext context) : base(context)
        {
        }

        public async Task<List<Remuneracao>> ObterRemuneracaoPorMes(Guid _mesId)
        {
            return await DbSet.Where(r => r.RemuneracaoMeses.Where(rm => rm.MesId == _mesId).Count() > 0).ToListAsync();
        }
    }
}