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
    public class ReceitaService : ServiceBase, IReceitaService
    {
        protected readonly IReceitaRepository _receitaRepository;
        public ReceitaService(INotificador notificador,
                                  IReceitaRepository receitaRepository) : base(notificador)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task Adicionar(Receita receita)
        {
            try
            {
                if (!ExecutarValidacao(new ReceitaValidator(), receita)) return;

                if (receita.SalarioMensal)
                {

                }
                await _receitaRepository.Adicionar(receita);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Dispose()
        {
            _receitaRepository?.Dispose();
        }


        #region Métodos Privados
    
        #endregion

    }
}
