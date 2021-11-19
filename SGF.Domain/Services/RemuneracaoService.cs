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
    public class RemuneracaoService : ServiceBase, IRemuneracaoService
    {
        protected readonly IRemuneracaoRepository _remuneracaoRepository;
        protected readonly IMesRepository _mesRepository;
        protected readonly IRemuneracaoMesRepository _remuneracaoMesRepository;
        public RemuneracaoService(INotificador notificador,
                                  IRemuneracaoRepository remuneracaoRepository,
                                  IMesRepository mesRepository,
                                  IRemuneracaoMesRepository remuneracaoMesRepository) : base(notificador)
        {
            _remuneracaoRepository = remuneracaoRepository;
            _mesRepository = mesRepository;
            _remuneracaoMesRepository = remuneracaoMesRepository;
        }

        public async Task Adicionar(Remuneracao remuneracao)
        {
            try
            {
                if (!ExecutarValidacao(new RemuneracaoValidator(), remuneracao)) return;

                if (remuneracao.SalarioMensal)
                {
                    await AdicionarMesesRemuneracao(remuneracao);
                }
                await _remuneracaoRepository.Adicionar(remuneracao);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Remuneracao>> ObterRemuneracaoPorMes(Guid _mesId)
        {
            try
            {
                return await _remuneracaoRepository.ObterRemuneracaoPorMes(_mesId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _remuneracaoRepository?.Dispose();
        }


        #region Métodos Privados
        /// <summary>
        /// Adiciona os vinculos de remuneração : meses refereciado
        /// </summary>
        /// <param name="remuneracao">objeto da remuneracao</param>
        /// <returns></returns>
        private async Task AdicionarMesesRemuneracao(Remuneracao remuneracao)
        {
            var meses = await _mesRepository.ObterMesesApartir(remuneracao.MesInicioId.Value, 2022);
            var mesInicio = await _mesRepository.ObterEntidadePorId(remuneracao.MesInicioId.Value);
            await TratarNovaRemuneracaoMensalParaMeses(mesInicio.Identificador_Numerico, 2022);

            meses.ForEach(m =>
            {
                remuneracao.RemuneracaoMeses.Add(
                    new RemuneracaoMes
                    {
                        MesId = m.Id,
                        RemuneracaoId = remuneracao.Id
                    });
            });
        }

        /// <summary>
        /// Encontra os meses que ja possuem algum salario mensal atribuido e os desvincula.
        /// </summary>
        /// <param name="mesInicio">inicio da verificação</param>
        /// <param name="Ano">qual ano consultar</param>
        /// <returns></returns>
        private async Task TratarNovaRemuneracaoMensalParaMeses(int mesInicioNum, int Ano)
        {
            var result = await _remuneracaoMesRepository.ObterRemuneracaoMesSalarioMensal(mesInicioNum, Ano);
            await _remuneracaoMesRepository.RemoverEntidades(result);
        }

        #endregion

    }
}
