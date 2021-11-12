using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities.Validations
{
    public class RemuneracaoValidator : AbstractValidator<Remuneracao>
    {
        public RemuneracaoValidator()
        {
            RuleFor(r => r.Valor)
                .NotNull().WithMessage("criar arquivo de mesagem ** valor nao pode ser nulo**");

            RuleFor(r => r.MesInicioId)
                .NotNull().When(r => r.SalarioMensal == true)
                .WithMessage("Para salarios mensais é necessario informar o mes de inicio do salario.");

            RuleFor(r => r.Descricao)
                .MaximumLength(150)
                .WithMessage("mensagem de valor maximo");
        }
    }
}
