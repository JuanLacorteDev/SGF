using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGF.Application.Interfaces.Application;
using SGF.Application.ViewModels;
using SGF.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemuneracaoController : CustomController
    {
        protected readonly IRemuneracaoApp _remuneracaoApp;
        public RemuneracaoController(INotificador notificador,
                                        IRemuneracaoApp remuneracaoApp) : base(notificador)
        {
            _remuneracaoApp = remuneracaoApp;
        }

        [HttpGet]
        public async Task<ActionResult<List<RemuneracaoVM>>> ObterRemuneracaoPorMes(Guid mesId)
        {
            return await _remuneracaoApp.ObterRemueracao(mesId);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(RemuneracaoVM remuneracao)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _remuneracaoApp.Adicionar(remuneracao);

            if (OperacaoValida()) return CustomResponse(remuneracao);

            return CustomResponse(remuneracao);
        }

    }
}
