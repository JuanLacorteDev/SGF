﻿using SGF.Domain.Entities;
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
    public class DespesaService : ServiceBase, IDespesaService
    {
        protected readonly IDespesaRepository _despesaRepository;
        public DespesaService(IDespesaRepository despesaRepository,
                              INotificador notificador): base(notificador)
        {
            _despesaRepository = despesaRepository;
        }

        public async Task<List<Despesa>> ObterDespesas(Guid userId)
        {
            try
            {
                var result = await _despesaRepository.BuscarPorExpressao(d => d.UserId == userId);
                return result.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public async Task Adicionar(Despesa despesa)
        {
            try
            {
                if (!ExecutarValidacao(new DespesaValidator(), despesa)) return;

                await _despesaRepository.Adicionar(despesa);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task Atualizar(Despesa despesa)
        {
            try
            {
                if (!ExecutarValidacao(new DespesaValidator(), despesa)) return;

                await _despesaRepository.Atualizar(despesa);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task Remover(Guid id)
        {
            await _despesaRepository.Remover(id);
        }

        public void Dispose()
        {
            _despesaRepository?.Dispose();
        }

        
    }
}
