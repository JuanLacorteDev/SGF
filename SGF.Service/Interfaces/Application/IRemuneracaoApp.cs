using SGF.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Application.Interfaces.Application
{
    public interface IRemuneracaoApp
    {
        Task Adicionar(RemuneracaoVM remueracao);
        Task<List<RemuneracaoVM>> ObterRemueracao(Guid MesId);
    }
}
