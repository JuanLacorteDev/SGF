using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGF.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : CustomController
    {
        protected readonly IDespesaService _despesaService;
        public DespesaController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        public async Task<ActionResult> AdicionarDespesa(object despesa)
        {
            //Criar ViewModels () => DespesaVM
            //await _despesaService.Adicionar(DespesaVM);
            return Ok();
        }
    }
}
