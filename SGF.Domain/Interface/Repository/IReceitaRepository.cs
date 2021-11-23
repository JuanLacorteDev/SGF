using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Repository
{
    public interface IReceitaRepository: IRepositoryBase<Receita>, IDisposable
    {
    }
}
