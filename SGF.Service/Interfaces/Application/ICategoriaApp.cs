using SGF.Application.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGF.Application.Interfaces.Application
{
    public interface ICategoriaApp
    {
        Task Adicionar(CategoriaAdicionarVM categoria);
        Task<List<CategoriaListarVM>> ObterCategorias(Guid? userId);
    }
}
