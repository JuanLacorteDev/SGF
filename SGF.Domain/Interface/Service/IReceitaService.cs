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
    }
}
