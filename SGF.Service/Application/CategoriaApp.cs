using AutoMapper;
using SGF.Application.Interfaces.Application;
using SGF.Application.ViewModels;
using SGF.Application.ViewModels.Entidades;
using SGF.Domain.Entities;
using SGF.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Application.Application
{
    public class CategoriaApp : ICategoriaApp
    {
        protected readonly ICategoriaService _categoriaService;
        protected readonly IMapper _mapper;
        public CategoriaApp(ICategoriaService categoriaService,
                            IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public async Task Adicionar(CategoriaAdicionarVM categoria)
        {
            await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoria));
        }

        public async Task<List<CategoriaListarVM>> ObterCategorias(Guid? userId)
        {
            var result = await _categoriaService.ObterCategorias(userId);
            return _mapper.Map<List<CategoriaListarVM>>(result);
        }
    }
}
