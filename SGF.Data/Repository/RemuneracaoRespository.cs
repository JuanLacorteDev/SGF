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
    public class RemuneracaoRespository : RepositoryBase<Remuneracao>, IRemuneracaoRepository
    {
        public RemuneracaoRespository(SGFDbContext context) : base(context)
        {
        }

        public async Task<Remuneracao> ObterRemuneracaoPorMes(Guid _mesId)
        {
            return await DbSet.FirstOrDefaultAsync(r => r.RemuneracaoMeses
                                                        .Select(x => x.MesId == _mesId).FirstOrDefault());  
        }
    }
}