using SGF.Domain.Entities;
using SGF.Domain.Entities.Validations;
using SGF.Domain.Interface.Repository;
using SGF.Domain.Interface.Service;
using SGF.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
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

                await _receitaRepository.Adicionar(receita);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
        public async Task<List<Receita>> ObterReceitasPorMes(double numMes)
        {
            try
            {
                return (await _receitaRepository.BuscarPorExpressao(r => r.Data_Lancamento.Month == numMes)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Receita>> ObterReceitas()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _receitaRepository?.Dispose();
        }


        #region Métodos Privados

        #endregion

    }
}
