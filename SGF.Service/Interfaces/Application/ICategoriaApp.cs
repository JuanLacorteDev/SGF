using SGF.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Application.Interfaces.Application
{
    public interface ICategoriaApp
    {
        Task Adicionar(CategoriaVM categoria);
        Task<List<CategoriaVM>> ObterCategorias();
    }
}
