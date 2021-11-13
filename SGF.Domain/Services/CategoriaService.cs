using SGF.Domain.Entities;
using SGF.Domain.Entities.Validations;
using SGF.Domain.Interface.Repository;
using SGF.Domain.Interface.Service;
using SGF.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Services
{
    public class CategoriaService : ServiceBase, ICategoriaService
    {
        protected readonly INotificador _notificador;
        protected readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(INotificador notificador,
                                ICategoriaRepository categoriaRepository) : base(notificador)
        {
            _notificador = notificador;
            _categoriaRepository = categoriaRepository;
        }

        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidator(), categoria)) return;

            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task<List<Categoria>> ObterCategorias()
        {
            return await _categoriaRepository.ObterTodasEntidades();
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
