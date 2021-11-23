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
    public class ReceitaRepository : RepositoryBase<Receita>, IReceitaRepository
    {
        public ReceitaRepository(SGFDbContext context) : base(context)
        {
        }

    }
}