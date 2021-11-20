using FluentValidation;
using SGF.Domain.Entities.Messages;

namespace SGF.Domain.Entities.Validations
{
    public class RemuneracaoValidator : AbstractValidator<Remuneracao>
    {
        public RemuneracaoValidator()
        {
            RuleFor(r => r.Valor)
                .NotNull().WithMessage(MessagesResource.E004);

            RuleFor(r => r.MesInicioId)
                .NotNull().When(r => r.SalarioMensal == true)
                .WithMessage(MessagesResource.E005);

            RuleFor(r => r.Descricao)
                .MaximumLength(150)
                .WithMessage(MessagesResource.E006);
        }
    }
}
