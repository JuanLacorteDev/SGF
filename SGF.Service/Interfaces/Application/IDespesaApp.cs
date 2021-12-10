using SGF.Application.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGF.Application.Interfaces.Application
{
    public interface IDespesaApp 
    {
        Task Adicionar(DespesaAdicionarVM despesa);
        Task<List<DespesaListarVM>> ObterDespesas(Guid userId);

    }
}
