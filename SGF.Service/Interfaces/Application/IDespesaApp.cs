using SGF.Application.ViewModels;
using System.Threading.Tasks;

namespace SGF.Application.Interfaces.Application
{
    public interface IDespesaApp
    {
        Task Adicionar(DespesaVM despesa);

    }
}
