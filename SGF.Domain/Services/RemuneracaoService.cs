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
    public class RemuneracaoService :  ServiceBase, IRemuneracaoService
    {
        protected readonly IRemuneracaoRepository _remuneracaoRepository;
        public RemuneracaoService(INotificador notificador,
                                 IRemuneracaoRepository  remuneracaoRepository ) : base(notificador)
        {
            _remuneracaoRepository = remuneracaoRepository;
        }

        public async Task Adicionar(Remuneracao remuneracao)
        {
            try
            {
                if (!ExecutarValidacao(new RemuneracaoValidator(), remuneracao)) return;

                if (remuneracao.SalarioMensal)
                {

                }

                await _remuneracaoRepository.Adicionar(remuneracao);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Remuneracao> ObterRemuneracaoPorMes(Guid _mesId)
        {
            try
            {
                return await _remuneracaoRepository.ObterRemuneracaoPorMes(_mesId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
