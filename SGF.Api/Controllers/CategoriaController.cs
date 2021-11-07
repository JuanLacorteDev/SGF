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
    public class CategoriaController : CustomController
    {
        protected readonly ICategoriaApp _categoriaApp;
        public CategoriaController(INotificador notificador,
                                   ICategoriaApp categoriaApp) : base(notificador)
        {
            _categoriaApp = categoriaApp;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaVM>>> ObterCategorias()
        {
            return await _categoriaApp.ObterCategorias();
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(CategoriaVM categoria)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaApp.Adicionar(categoria);

            if (OperacaoValida()) return Ok();

            return BadRequest();
        }

    }
}
