using SGF.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGF.Application.Interfaces.Application
{
    public interface IDespesaApp 
    {
        Task Adicionar(DespesaVM despesa);
        Task<List<DespesaVM>> ObterDespesas();

    }
}
