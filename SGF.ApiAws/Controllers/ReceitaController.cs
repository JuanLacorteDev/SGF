using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGF.Application.Interfaces.Application;
using SGF.Application.ViewModels;
using SGF.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGF.ApiAws.Controllers
{
    [Route("api/[controller]")]
    public class ReceitaController : CustomController
    {
        protected readonly IReceitaApp _remuneracaoApp;
        public ReceitaController(INotificador notificador,
                                        IReceitaApp remuneracaoApp) : base(notificador)
        {
            _remuneracaoApp = remuneracaoApp;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReceitaVM>>> ObterReceitas()
        {
            return await _remuneracaoApp.ObterReceitas();
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(ReceitaVM remuneracao)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _remuneracaoApp.Adicionar(remuneracao);

            if (OperacaoValida()) return CustomResponse(remuneracao);

            return CustomResponse(remuneracao);
        }

    }
}
