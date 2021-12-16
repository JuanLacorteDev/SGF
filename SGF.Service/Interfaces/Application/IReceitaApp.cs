using SGF.Application.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Application.Interfaces.Application
{
    public interface IReceitaApp
    {
        Task Adicionar(ReceitaVM receita);
        Task<List<ReceitaVM>> ObterReceitas();
    }
}
