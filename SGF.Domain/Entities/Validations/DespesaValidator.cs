using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities.Validations
{
    public class DespesaValidator : AbstractValidator<Despesa>
    {
        public DespesaValidator()
        {
            RuleFor(d => d.Valor)
                .NotEmpty().WithMessage("Criar arquivo de mensagens **Valor Vazio**");

            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage("Criar arquivo de mensagens **Nome Vazio**");
        }
    }
}
