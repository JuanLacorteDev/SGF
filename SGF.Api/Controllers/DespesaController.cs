using Microsoft.AspNetCore.Mvc;
using SGF.Application.Interfaces.Application;
using SGF.Application.ViewModels;
using SGF.Domain.Interfaces.Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : CustomController
    {
        protected readonly IDespesaApp _despesaApp;
        public DespesaController(IDespesaApp depesaApp,
                                 INotificador notificador) : base(notificador)
        {
            _despesaApp = depesaApp;
        }

        [HttpGet]
        public async Task<ActionResult<List<DespesaCategoriasMesesVM>>> ObterDespesas()
        {
            return await _despesaApp.ObterDespesas();
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarDespesa(DespesaVM despesa)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _despesaApp.Adicionar(despesa);

            if(OperacaoValida()) return CustomResponse(despesa);

            return CustomResponse(despesa);
        }
    }
}
