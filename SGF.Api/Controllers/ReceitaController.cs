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
    public class ReceitaController : CustomController
    {
        protected readonly IReceitaApp _receitaApp;
        public ReceitaController(INotificador notificador,
                                        IReceitaApp receitaApp) : base(notificador)
        {
            _receitaApp = receitaApp;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReceitaVM>>> ObterReceitaPorMes()
        {
            return await _receitaApp.ObterReceitas();
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(ReceitaVM receita)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _receitaApp.Adicionar(receita);

            if (OperacaoValida()) return CustomResponse(receita);

            return CustomResponse(receita);
        }

    }
}
