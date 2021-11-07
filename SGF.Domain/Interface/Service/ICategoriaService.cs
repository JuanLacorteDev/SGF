using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Service
{
    public interface ICategoriaService : IDisposable
    {
        Task Adicionar(Categoria categoria);
        Task<List<Categoria>> ObterCategorias();
    }
}
