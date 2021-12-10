using Microsoft.AspNetCore.Mvc;
using SGF.Application.Interfaces.Application;
using SGF.Application.ViewModels.Entidades;
using SGF.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGF.ApiAws.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : CustomController
    {
        protected readonly ICategoriaApp _categoriaApp;
        public CategoriaController(INotificador notificador,
                                   ICategoriaApp categoriaApp) : base(notificador)
        {
            _categoriaApp = categoriaApp;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaListarVM>>> ObterCategorias(Guid? userId)
        {
            return await _categoriaApp.ObterCategorias(userId);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(CategoriaAdicionarVM categoria)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaApp.Adicionar(categoria);

            if (OperacaoValida()) return Ok();

            return BadRequest();
        }

    }
}
