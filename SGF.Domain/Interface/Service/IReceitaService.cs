using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Service
{
    public interface IReceitaService : IDisposable
    {
        Task Adicionar(Receita receita);
        Task<List<Receita>> ObterReceitas();
        Task<List<Receita>> ObterReceitasPorMes(double numMes);
    }
}
