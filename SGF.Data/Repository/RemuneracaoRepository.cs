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

        public async Task<Remuneracao> ObterRemuneracaoPorMes(Guid _mesId)
        {
            return await DbSet.FirstOrDefaultAsync(r => r.RemuneracaoMeses
                                                        .Select(x => x.MesId == _mesId).FirstOrDefault());  
        }
    }
}